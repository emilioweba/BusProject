using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Application
{
    class DBLandmark
    {
        private Teste_OnibusContext dBase { get; set; }
        public DBLandmark(Teste_OnibusContext dBase)
        {
            this.dBase = dBase;
        }

        public void Add(LANDMARK landmark)
        {
            dBase.LANDMARKs.Add(landmark);
            dBase.SaveChanges();
        }

        public IEnumerable<LANDMARK> SelectAll()
        {
            return dBase.LANDMARKs.ToList();
        }

        public IEnumerable<Coordinates> SelectLike(string keywords)
        {
            return from landmark in dBase.LANDMARKs
                   join landID in dBase.LANDMARK_KNOWN_AS on landmark.Landmark_ID equals landID.Landmark_FK
                   where landID.Known_As_Description.Equals(keywords)
                   select new Coordinates { Landmark = landmark, LandmarkKnownAs = landID };
        }

        public IEnumerable<Coordinates> SelectLandmarkDescription()
        {
            return from landmark in dBase.LANDMARKs
                   join landID in dBase.LANDMARK_KNOWN_AS on landmark.Landmark_ID equals landID.Landmark_FK
                   select new Coordinates { Landmark = landmark, LandmarkKnownAs = landID };
        }

        public void Edit(LANDMARK landmark, LANDMARK_KNOWN_AS lka)
        {
            var results = from p in dBase.LANDMARKs
            join q in dBase.LANDMARK_KNOWN_AS on p.Landmark_ID equals q.Landmark_FK
            select new { p, q };
            
            foreach (var item in results)
            {
                item.p.Landmark_Coordinates = landmark.Landmark_Coordinates;
                item.q.Known_As_Description = lka.Known_As_Description;
            }

            dBase.SaveChanges();
        }

        public void Delete(int ID)
        {
            dBase.LANDMARK_KNOWN_AS.Remove(dBase.LANDMARK_KNOWN_AS.Where(x => x.Known_As_ID == ID).First());
            dBase.LANDMARKs.Remove(dBase.LANDMARKs.Where(x => x.Landmark_ID == ID).First());
            dBase.SaveChanges();
        }

        public void DeleteAll()
        {
            using (var transaction = dBase.Database.BeginTransaction())
                try
                {
                    dBase.Database.ExecuteSqlCommand("DELETE FROM LANDMARK_KNOWN_AS");
                    dBase.Database.ExecuteSqlCommand("DELETE FROM LANDMARKS");
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
        }

    }
}
