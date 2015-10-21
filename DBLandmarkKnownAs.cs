using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Application
{
    class DBLandmarkKnownAs
    {
        private Teste_OnibusContext dBase { get; set; }
        public DBLandmarkKnownAs(Teste_OnibusContext dBase)
        {
            this.dBase = dBase;
        }

        public void Add(LANDMARK_KNOWN_AS landmark)
        {
            dBase.LANDMARK_KNOWN_AS.Add(landmark);
            dBase.SaveChanges();
        }

        public IEnumerable<LANDMARK_KNOWN_AS> SelectAll()
        {
            return dBase.LANDMARK_KNOWN_AS.ToList();
        }

        //public void Edit(LANDMARK landmark, LANDMARK_KNOWN_AS lka)
        //{
        //    //LANDMARK tempLandmark = dBase.LANDMARKs.Where(x => x.Landmark_ID == landmark.Landmark_ID).First();

        //    var results = from p in dBase.LANDMARKs
        //    join q in dBase.LANDMARK_KNOWN_AS on p.Landmark_ID equals q.Landmark_FK
        //    select new { p, q };
            
        //    foreach (var item in results)
        //    {
        //        item.p.Landmark_Coordinates = landmark.Landmark_Coordinates;
        //        item.q.Known_As_Description = lka.Known_As_Description;
        //    }

        //    dBase.SaveChanges();
        //}

        public void Delete(int ID)
        {
            dBase.LANDMARK_KNOWN_AS.Remove(dBase.LANDMARK_KNOWN_AS.Where(x => x.Known_As_ID == ID).First());
            dBase.SaveChanges();
        }

    }
}
