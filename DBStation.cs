using SharpKml.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Application
{
    class DBStation
    {
        private Teste_OnibusContext dBase { get; set; }
        public DBStation(Teste_OnibusContext dBase)
        {
            this.dBase = dBase;
        }

        public void Add(STATION station)
        {
            dBase.STATIONS.Add(station);
            dBase.SaveChanges();
        }

        public IEnumerable<STATION> Select()
        {
            return dBase.STATIONS.ToList();
        }

        public IList<STATION> SelectStationsNear(int distance, DbGeography point)
        {
            return dBase.STATIONS.Where(p => p.Station_Coordinates.Distance(point).Value < distance).ToList();
        }

        public void Edit(STATION station)
        {
            STATION tempStation = dBase.STATIONS.Where(x => x.Station_ID == station.Station_ID).First();
            tempStation.Station_Description = station.Station_Description;
           

            dBase.SaveChanges();
        }

        public void Delete(int ID)
        {
            foreach (var item in dBase.STATION_BUSES.Where(x => x.Stations_Fk == ID))
                dBase.STATION_BUSES.Remove(item);
            
            dBase.STATIONS.Remove(dBase.STATIONS.Where(x => x.Station_ID == ID).First());
            dBase.SaveChanges();
        }

        public void DeleteAll()
        {
            using (var transaction = dBase.Database.BeginTransaction())
                try
                {
                    dBase.Database.ExecuteSqlCommand("DELETE FROM STATIONS");
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
        }

    }
}
