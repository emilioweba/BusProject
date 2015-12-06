using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Application
{
    class DBBus
    {
        private Teste_OnibusContext dBase { get; set; }
        public DBBus(Teste_OnibusContext dBase)
        {
            this.dBase = dBase;
        }

        public void Add(BUS bus)
        {
            dBase.BUS.Add(bus);
            dBase.SaveChanges();
        }

        public IEnumerable<BUS> Select()
        {
            return dBase.BUS.ToList();
        }

        public void Edit(BUS bus)
        {
            BUS tempBus = dBase.BUS.Where(x => x.Bus_ID == bus.Bus_ID).First();
            tempBus.Bus_Description = bus.Bus_Description;
            tempBus.Bus_Color = bus.Bus_Color;
            tempBus.Bus_Provider = bus.Bus_Provider;

            dBase.SaveChanges();
        }

        public void Delete(int ID)
        {
            dBase.ROUTEs.Remove(dBase.ROUTEs.Where(x => x.Bus_ID == ID).First());

            foreach (var item in dBase.STATION_BUSES.Where(x => x.Buses_FK == ID))
                dBase.STATION_BUSES.Remove(item);
            
            dBase.BUS.Remove(dBase.BUS.Where(x => x.Bus_ID == ID).First());
            dBase.SaveChanges();
        }

        public void DeleteAll()
        {
            using (var transaction = dBase.Database.BeginTransaction())
                try
                {
                    dBase.Database.ExecuteSqlCommand("DELETE FROM ROUTES");
                    dBase.Database.ExecuteSqlCommand("DELETE FROM STATION_BUSES");
                    dBase.Database.ExecuteSqlCommand("DELETE FROM BUS");
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
        }

    }
}
