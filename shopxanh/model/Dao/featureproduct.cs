using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model.EF;

namespace model.Dao
{
   public class featureproduct
    {
        ShoponlineDB db = null;
        
        public featureproduct()
        {
            db = new ShoponlineDB();
        }
        public List<Product>lisfeature(int top)
        {
            return db.Products.Where(x => x.CategoryID == 6 &&x.Status==true).OrderByDescending(x=>x.CreatedDate).Take(top).ToList();
        }
    }
}
