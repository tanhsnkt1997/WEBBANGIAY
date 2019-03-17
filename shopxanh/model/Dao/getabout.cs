using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model.EF;

namespace model.Dao
{
    public class getabout
    {
        ShoponlineDB db = null;
        public getabout()
        {
            db = new ShoponlineDB();
        }
        public List<About> listall()
        {
            return db.Abouts.Where(x => x.Status == true).ToList();
        }
    }
}
