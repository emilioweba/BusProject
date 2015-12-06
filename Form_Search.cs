using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using SharpKml.Base;
using SharpKml.Dom;
using SharpKml.Engine;
using System.IO;
using System.Reflection;
using GoogleMaps.LocationServices;
using System.Net;
using System.Web.Script.Serialization;
using System.Collections;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.Data.Entity.Spatial;

namespace Bus_Application
{
    public partial class Form_Search : Form
    {
        public Form_Search()
        {
            InitializeComponent();
        }

        #region BasicEvents

        private void Form_Search_Load(object sender, EventArgs e)
        {
            loadStationCombobox();
        }

        public void loadStationCombobox()
        {
            using (Teste_OnibusContext db = new Teste_OnibusContext())
            {

                db.Database.Connection.Open();

                //DBStation db = new DBStation(new Teste_OnibusContext());

                IEnumerable<STATION> enumerable = db.STATIONS.ToList();

                cboStation.DataSource = enumerable;
                cboStation.DisplayMember = "Station_Description";
                cboStation.ValueMember = "Station_ID";

                txtDistance.Visible = false;
                lblDistance.Visible = false;
                lblMeters.Visible = false;
            }
        }

        private void rotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageRoute formRoute = new ManageRoute(this);
            formRoute.Visible = true;
            this.Enabled = false;
        }

        private void pontoDeReferenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageReference formReference = new ManageReference(this);
            formReference.Visible = true;
            this.Enabled = false;
        }

        private void onibusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageBus formBus = new ManageBus(this);
            formBus.Visible = true;
            this.Enabled = false;
        }

        private void uploadKMLEstaçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UploadKML uploadKmlStations = new UploadKML(this);
            uploadKmlStations.Visible = true;
            this.Enabled = false;
        }

        private void txtKeyword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnSearch_Click(this, new EventArgs());
        }
        private void txtDistance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnSearch_Click(this, new EventArgs());
        }

        private void estaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageStations formStation = new ManageStations(this);
            formStation.Visible = true;
            this.Enabled = false;
        }

        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cboBuses.DataSource = null;
            lblMessage.Text = String.Empty;
            try
            {
                int distance = 300;
                //if (!getDistance(ref distance))
                //{
                //    throw new Exception("Distância inserida em formato incorreto. Favor utilizar apenas números inteiros acima de zero.");
                //}

                Teste_OnibusContext context = new Teste_OnibusContext();
                DBLandmark DBlandmark = new DBLandmark(context);

                //consulta as coordenadas do ponto de referencia
                IEnumerable<Coordinates> landmarkResult = DBlandmark.SelectLike(processString(txtKeyword.Text));

                if (landmarkResult.Count() > 1)
                {
                    Methods.DisplayMessage(lblMessage, "More then one place has this name. Plese be more specific.", Color.Red); //Especificar melhor a busca
                }
                else if (landmarkResult.Count() == 0)
                {
                    Methods.DisplayMessage(lblMessage, "No local was found with this description", Color.Red);
                    //fillRecommendedBuses(kml, getCoordinatesReference(txtKeyword.Text)); //pesquisa no Google Maps
                }
                else
                {
                    //txtResultPontoReferencia.Text = landmarkResult.ElementAt(0).LandmarkKnownAs.Known_As_Description;

                    fillRecommendedBuses(landmarkResult.ElementAt(0).Landmark.Landmark_Coordinates, context, (STATION)cboStation.SelectedItem, distance); //ja está cadastrado no Banco de Dados
                    Methods.DisplayMessage(lblMessage, "See your recommended buses!", Color.Green);
                }
            }
            catch (Exception ex)
            {
                Methods.DisplayMessage(lblMessage, ex.Message, Color.Red);
            }

        }

        private void fillRecommendedBuses(DbGeography coordinatesReference, Teste_OnibusContext context, STATION selectedStation, int distance)
        {
            List<BUS> recommendedBus = new List<BUS>();
            DBStation_Bus dbStationBus = new DBStation_Bus(context);

            // seleciona os ônibus que passam na estação a menos de DISTANCE metros do ponto de referência
            var stationsNear = dbStationBus.SelectStationsNear(distance, coordinatesReference);

            foreach (var station in stationsNear)
            {
                // para cada ônibus que passa no ponto de refência, verifica se ele também passa na estação em que o usuário está
                var busInStation = dbStationBus.SelectStationBus(station.BUS, selectedStation);

                foreach (var item in busInStation)
                {
                    if (!recommendedBus.Contains(item.Bus)) // se passar, recomenda ele para o usuário
                        recommendedBus.Add(item.Bus);
                }
            }

            cboBuses.DataSource = recommendedBus.Select(x => x.Bus_Description).ToList();
        }

        //Compara o kml dos onibus com as coordenadas do ponto de referencia inserido pelo usuario
        private void compareCoordinates(Folder folder, double[] coordinatesReference, List<string> recommendedBus)
        {
            IEnumerable<Vector> list = Enumerable.Empty<Vector>();

            foreach (var placemark in folder.Flatten().OfType<Placemark>())
            {
                foreach (var coordinates in placemark.Geometry.Flatten().OfType<CoordinateCollection>())
                {
                    list = coordinates.Where(x =>
                        MathHelpers.Distance(coordinatesReference[0], coordinatesReference[1], x.Latitude, x.Longitude) < 500);

                    if (list.Count() > 0)
                    {
                        recommendedBus.Add(folder.Name);
                        return;
                    }
                }
            }
        }

        private double[] getCoordinatesReference(string referenceDescription) //pesquisa no Google Maps
        {
            using (var client = new WebClient())
            {
                StringBuilder urlMap = new StringBuilder("");

                urlMap.Append("http://maps.googleapis.com/maps/api/geocode/json?address=");

                string url = referenceDescription.Replace(' ', '+');

                urlMap.Append(url);
                urlMap.Append("&sensor=false&bounds=-2.660950,-44.382405|-2.406454,-44.020543"); //restringe a busca em Sao Luis

                //textBox2.Text = urlMap.ToString();

                //var oi = client.DownloadString("https://www.google.com/maps/search/Churrascaria+Barriga+Verde+Sao+Luis/");
                //var ser = new XmlSerializer(typeof(object));

                var json = client.DownloadString(urlMap.ToString());
                var serializer = new JavaScriptSerializer();
                var dict = serializer.Deserialize<dynamic>(json);

                //textBox1.Text = dict["results"][0]["geometry"]["location"]["lat"].ToString() + "," + dict["results"][0]["geometry"]["location"]["lng"].ToString();

                return new double[2] { double.Parse(dict["results"][0]["geometry"]["location"]["lat"].ToString()), double.Parse(dict["results"][0]["geometry"]["location"]["lng"].ToString()) };
            }

        }

        private bool getDistance(ref int distance)
        {
            return int.TryParse(txtDistance.Text, out distance);
        }

        private string processString(string text)
        {
            return Regex.Replace(text.Replace(',', ' '), @"\s+", " ").Trim().ToUpper();
        }

        private void Form_Search_Activated(object sender, EventArgs e)
        {
            loadStationCombobox();
        }
    }
}
