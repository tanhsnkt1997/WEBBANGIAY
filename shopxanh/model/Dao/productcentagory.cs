using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model.EF;

namespace model.Dao
{
    public class productcentagory
    {
        ShoponlineDB db = null;

        public productcentagory()
        {
            db = new ShoponlineDB();
        }
        public List<ProductCategorie> listall()
        {
            return db.ProductCategories.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();

        }
        public ProductCategorie viewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }
    }

}
