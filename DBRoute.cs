using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Application
{
    class DBRoute
    {
        private Teste_OnibusContext dBase { get; set; }
        public DBRoute(Teste_OnibusContext dBase)
        {
            this.dBase = dBase;
        }

        public void Add(ROUTE route)
        {
            dBase.ROUTEs.Add(route);
            dBase.SaveChanges();
        }

        public IEnumerable<ROUTE> Select()
        {
            return dBase.ROUTEs.ToList();
        }

        public IEnumerable<RouteBus> SelectRouteBus()
        {
            return from route in dBase.ROUTEs
                   join bus in dBase.BUS on route.Bus_ID equals bus.Bus_ID
                   //where bus.Known_As_Description.Equals(keywords)
                   select new RouteBus { Route = route, Bus = bus };
        }

        //public void Edit(ROUTE ROUTE)
        //{
        //    ROUTE tempROUTE = dBase.ROUTEs.Where(x => x.ROUTE_ID == ROUTE.ROUTE_ID).First();
        //    tempROUTE.ROUTE_Description = ROUTE.ROUTE_Description;
        //    tempROUTE.ROUTE_Color = ROUTE.ROUTE_Color;
        //    tempROUTE.ROUTE_Provider = ROUTE.ROUTE_Provider;

        //    dBase.SaveChanges();
        //}

        //public void Delete(int ID)
        //{
        //    ROUTE tempROUTE = dBase.ROUTEs.Where(x => x.ROUTE_ID == ID).First();
        //    dBase.ROUTEs.Remove(tempROUTE);
        //    dBase.SaveChanges();

        //}

    }
}
