using SharpKml.Dom;
using SharpKml.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Spatial;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bus_Application
{
    public partial class UploadKML : Form
    {
        Form parentForm;
        Teste_OnibusContext context;

        public UploadKML(Form parent)
        {
            InitializeComponent();
            this.parentForm = parent;
            btnBrowse.Enabled = false;
        }
        
        #region Basic Events

        private void rdbStations_CheckedChanged(object sender, EventArgs e)
        {
            lblMessage.Text = String.Empty;
            btnBrowse.Enabled = true;
        }

        private void rdbReferences_CheckedChanged(object sender, EventArgs e)
        {
            lblMessage.Text = String.Empty;
            btnBrowse.Enabled = true;
        }

        private void btnClearStationReferences_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja deletar todos os pontos de referência?", "Confirmação", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    using (context = new Teste_OnibusContext())
                    {
                        DBLandmark db = new DBLandmark(context);
                        db.DeleteAll();
                        Methods.DisplayMessage(lblMessage, "Todos os registros deletados com sucesso!", Color.Green);
                    }
                }
                catch (Exception ex)
                {
                    Methods.DisplayMessage(lblMessage, "Não foi possível deletar os registros!", Color.Red);
                }
            }
        }

        private void chbBus_CheckedChanged(object sender, EventArgs e)
        {
            lblMessage.Text = String.Empty;
            rdbReferences.Checked = false;
            rdbStations.Checked = false;

            if (chbBus.Checked)
            {
                rdbReferences.Enabled = false;
                rdbStations.Enabled = false;
                btnBrowse.Enabled = true;
            }
            else
            {
                rdbReferences.Enabled = true;
                rdbStations.Enabled = true;
                btnBrowse.Enabled = false;
            }
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            rdbReferences.Checked = false;
            rdbStations.Checked = false;
            chbBus.Checked = false;
        }

        private void UploadKMLStations_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentForm.Enabled = true;
            parentForm.Activate();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja deletar todos os registros?", "Confirmação", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    using (context = new Teste_OnibusContext())
                    {
                        DBLandmark dbLandmark = new DBLandmark(context);
                        dbLandmark.DeleteAll();

                        DBBus dbBus = new DBBus(context);
                        dbBus.DeleteAll();

                        DBStation dbStation = new DBStation(context);
                        dbStation.DeleteAll();

                        Methods.DisplayMessage(lblMessage, "Todos os registros deletados com sucesso!", Color.Green);
                    }
                }
                catch (Exception ex)
                {
                    Methods.DisplayMessage(lblMessage, "Não foi possível deletar os registros!", Color.Red);
                }
            }
        }

        #endregion

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "KML|*.kml";
            lblMessage.Text = "";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (context = new Teste_OnibusContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            KmlFile kml = Methods.OpenFile(openFileDialog1.FileName, lblMessage);
                            bool done = false;

                            if (chbBus.Checked)
                            {
                                done = addBusRoutes(kml); // cadastro o ônibus, a rota e faço o join com as estações em que ele passa
                            }
                            else if (rdbStations.Checked || rdbReferences.Checked) // cadastro as estações ou os pontos de referência
                            { 
                                if (kml.Root.Flatten().OfType<Folder>().Any())
                                    done = parseFolder(kml, done);
                                else
                                    done = parsePlacemark(kml.Root.Flatten().OfType<Placemark>(), done);
                            }
 
                            transaction.Commit();
                            
                            if(done)
                                Methods.DisplayMessage(lblMessage, "Carga realizada com sucesso!", Color.Green);
                            else
                                Methods.DisplayMessage(lblMessage, "Nenhuma operação foi realizada!", Color.Red);
                            
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Methods.DisplayMessage(lblMessage, "Erro! Não foi possível completar a transação. Consulte Emilio Weba :P", Color.Red);
                        }
                    }
                }
            }

        }

        #region Add BusRoutes

        /* Código referente ao cadastro dos Ônibus juntamente com suas Rotas. 
         É feito um join da rota do ônibus com as estações em que ele passa. Portanto, DEVE ser feito o 
            cadastro das estações de ônibus ANTES de adicionar a rota.
         É realizado um insert nas tabelas BUSES, ROUTES e STATION_BUSES */

        private bool addBusRoutes(KmlFile kml)
        {
            BUS bus = new BUS();
            ROUTE route = new ROUTE();
            DBRoute dbRoute = new DBRoute(context);
            DBStation dbStation = new DBStation(context);

            route.BUS = bus;

            StringBuilder sb = new StringBuilder("LINESTRING (");
            bus.Bus_Description = Methods.getBusDescription(kml);
            bool hasStation = false;

            foreach (var folder in kml.Root.Flatten().OfType<Folder>())
            {
                if (folder.Flatten().OfType<SharpKml.Dom.LineString>().Any())
                {
                    DBStation_Bus dbStationBus = new DBStation_Bus(context);

                    foreach (var placemark in folder.Flatten().OfType<SharpKml.Dom.Placemark>())
                    {
                        parseLineString(placemark, sb); // grava a rota do onibus
                        hasStation = parsePoint(placemark, dbStationBus, dbStation, bus, route, hasStation); // grava as estacoes que o onibus passa
                    }
                }
            }

            if (!hasStation)
            {
                string message = "As estações em que este ônibus passa não estão cadastradas. Por favor, cadastre primeiro as estações, depois a rota do ônibus";
                Methods.DisplayMessage(lblMessage, message, Color.Red);
                throw new Exception(message);
            }

            route.Route_Coordinates = DbGeography.LineFromText(sb.Replace(',', ')', sb.Length - 1, 1).ToString(), 4326);

            dbRoute.Add(route);
            return true;
        }

        private void parseLineString(Placemark placemark, StringBuilder sb)
        {
            if (chbBus.Checked)
            {
                foreach (var lineString in placemark.Flatten().OfType<SharpKml.Dom.LineString>())
                {
                    sb.Append(string.Join(" ",
                        lineString.Coordinates.Select(x => x.Latitude.ToString() + " " + x.Longitude.ToString() + ",")));
                }
            }
        }

        private bool parsePoint(Placemark placemark, DBStation_Bus dbStationBus, DBStation dbStation, BUS bus, ROUTE route, bool hasStation)
        {
            foreach (var lineString in placemark.Flatten().OfType<SharpKml.Dom.Point>())
            {
                IList<STATION> stationsNear = dbStation.SelectStationsNear(50,
                    Methods.ConvertLatLonToDbGeography(lineString.Coordinate.Longitude, lineString.Coordinate.Latitude));

                foreach (var station in stationsNear)
                {
                    STATION_BUSES stationBus = new STATION_BUSES();

                    stationBus.STATION = station;
                    stationBus.BUS = bus;

                    dbStationBus.AddStation_Buses_Route(route, stationBus);
                    hasStation = true;
                }
            }
            return hasStation;
        }

        #endregion Add BusRoutes

        #region Add References or Stations

        // Código referente ao cadastro dos Pontos de Referência OU das Estações de Ônibus
        // É realizado um insert nas tabelas STATIONS OU LANDMARKs e LANDMARK_KNOWN_AS
        private bool parseFolder(KmlFile kml, bool done)
        {
            foreach (var folder in kml.Root.Flatten().OfType<Folder>())
            {
                IEnumerable<Placemark> enumerablePlacemark = null;

                if (folder.Flatten().OfType<Placemark>().Any())
                    enumerablePlacemark = folder.Flatten().OfType<Placemark>();

                done = parsePlacemark(enumerablePlacemark, done, kml);
            }
            return done;
        }

        private bool parsePlacemark(IEnumerable<Placemark> enumerablePlacemark, bool done, KmlFile kml = null)
        {
            foreach (var placemark in enumerablePlacemark)
            {
                done = parsePoint(placemark, done);
                if (placemark.Flatten().OfType<SharpKml.Dom.LineString>().Any())
                {
                    BUS bus = new BUS();
                    bus.Bus_Description = Methods.getBusDescription(kml);
                }
            }
            return done;
        }
        private bool parsePoint(Placemark placemark, bool done)
        {
            foreach (var point in placemark.Geometry.Flatten().OfType<SharpKml.Dom.Point>())
            {
                DbGeography coordinates = DbGeography.PointFromText("POINT (" + point.Coordinate.Longitude
                + " " + point.Coordinate.Latitude + ")", 4326);

                if (rdbStations.Checked)
                {
                    addStation(placemark, point, coordinates);
                    done = true;
                }
                else if (rdbReferences.Checked)
                {
                    addReference(placemark, point, coordinates);
                    done = true;
                }
            }
            return done;
        }

        private void addStation(Placemark placemark, SharpKml.Dom.Point point, DbGeography coordinates)
        {
            STATION station = new STATION();

            station.Station_Description = placemark.Name;
            station.Station_Coordinates = coordinates;

            DBStation db = new DBStation(context);
            db.Add(station);
        }

        private void addReference(Placemark placemark, SharpKml.Dom.Point point, DbGeography coordinates)
        {
            LANDMARK landmark = new LANDMARK();
            LANDMARK_KNOWN_AS knowAsLandmark;

            knowAsLandmark = new LANDMARK_KNOWN_AS();

            knowAsLandmark.Known_As_Description = placemark.Name;
            landmark.Landmark_Coordinates = coordinates;
            knowAsLandmark.LANDMARK = landmark;

            DBLandmarkKnownAs db = new DBLandmarkKnownAs(context);
            db.Add(knowAsLandmark);

            if (placemark.Description != null)
            {
                string[] description = placemark.Description.Text.Split(';');

                for (int i = 0; i < description.Count(); i++)
                {
                    knowAsLandmark = new LANDMARK_KNOWN_AS();

                    knowAsLandmark.Known_As_Description = description[i];
                    landmark.Landmark_Coordinates = coordinates;

                    knowAsLandmark.LANDMARK = landmark;

                    db = new DBLandmarkKnownAs(context);
                    db.Add(knowAsLandmark);
                }
            }
        }

        #endregion Add References or Stations

        
    }
}
