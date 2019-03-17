using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model.EF;


namespace model.Dao
{
    public class getcontact
    {
        ShoponlineDB db = null;

        public getcontact()
        {
            db = new ShoponlineDB();
        }
        public Contant listcontact()
        {
            return db.Contants.Single();
        }
        public int InsertFeedBack(Feedback fb)
        {
            db.Feedbacks.Add(fb);
            db.SaveChanges();
            return fb.ID;
        }
    }
}
