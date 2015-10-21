using SharpKml.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Application
{
    class DBStation_Bus
    {
        private Teste_OnibusContext dBase { get; set; }
        public DBStation_Bus(Teste_OnibusContext dBase)
        {
            this.dBase = dBase;
        }

        public IList<STATION_BUSES> SelectStationsNear(int distance, DbGeography point) // procura por estações que estão à distancia X das coordenadas do ponto
        {
            return dBase.STATION_BUSES.Where(p => p.STATION.Station_Coordinates.Distance(point).Value < distance).ToList();
        }

        public void Add(STATION_BUSES stationBus)
        {
            dBase.STATION_BUSES.Add(stationBus);
            dBase.SaveChanges();
        }

        public IEnumerable<STATION_BUSES> Select()
        {
            return dBase.STATION_BUSES.ToList();
        }

        public void AddStation_Buses_Route(ROUTE route, STATION_BUSES stationBus)
        {
            dBase.STATION_BUSES.Add(stationBus);
            dBase.SaveChanges();
        }
        // seleciona os ônibus que passam na estação
        public IEnumerable<StationBus> SelectStationBus(BUS bus, STATION station) 
        {
            return from station_bus in dBase.STATION_BUSES
                   join stations in dBase.STATIONS on station_bus.Stations_Fk equals stations.Station_ID
                   join buses in dBase.BUS on station_bus.Buses_FK equals buses.Bus_ID
                   where stations.Station_ID == station.Station_ID
                   where buses.Bus_ID == bus.Bus_ID
                   select new StationBus { Station = stations, Bus = buses };
        }

        //public void Edit(STATION_BUSES station)
        //{
        //    STATION_BUSES tempStation = dBase.STATION_BUSES.Where(x => x.Station_ID == station.Station_ID).First();
        //    tempStation.Station_Description = station.Station_Description;
        //    tempStation.Station_Latitude = station.Station_Latitude;
        //    tempStation.Station_Longitude = station.Station_Longitude;

        //    dBase.SaveChanges();
        //}

        public void Delete(int ID)
        {
            STATION_BUSES tempStationBus = dBase.STATION_BUSES.Where(x => x.Station_Buses_ID == ID).First();
            dBase.STATION_BUSES.Remove(tempStationBus);
            dBase.SaveChanges();

        }

    }
}
