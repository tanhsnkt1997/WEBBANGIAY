using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model.EF;

namespace model.Dao
{
    public class getslide
    {
        ShoponlineDB db = null;

        public getslide()
        {
            db = new ShoponlineDB();
        }
        public List<Slide> listall()
        {
            return db.Slides.Where(x => x.Status == true).ToList();
        } 
     
    }
}
