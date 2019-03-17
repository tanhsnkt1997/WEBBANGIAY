using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model.EF;

namespace model.Dao
{
    public class listnewproduct
    {
        ShoponlineDB db = null;

        public listnewproduct()
        {
            db = new ShoponlineDB();
        }
       public List<Product>listnew(int id)
        {
            return db.Products.Where(x => x.CategoryID == 5 &&x.Status==true).Take(id).ToList();
        }
    }
}
