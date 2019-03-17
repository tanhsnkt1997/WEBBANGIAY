using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model.EF;

namespace model.Dao
{
    public class getfooter
    {
        ShoponlineDB db = null;

        public getfooter()
        {
            db = new ShoponlineDB();
        }
        public Footer listall()
        {
            return db.Footers.FirstOrDefault(x=>x.Status==true);
        }
    }
}
