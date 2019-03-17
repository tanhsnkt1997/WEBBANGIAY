using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model.EF;

namespace model.Dao
{
    public class getbaner
    {
        ShoponlineDB db = null;
        public getbaner()
        {
            db = new ShoponlineDB();
        }
        public Bandner listall()
        {
            return db.Bandners.Single(x => x.Status == true);
        }
    }
}
