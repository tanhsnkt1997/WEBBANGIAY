using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model.EF;

namespace model.Dao
{
    public class Getmenu
    {
        ShoponlineDB db=null;
        public Getmenu()
            {
            db = new ShoponlineDB(); 
            }
        public List<Menu> listbygroupuid(int groupid)
            {
            return db.Menus.Where(x => x.Status == true && x.GroupID == groupid).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}
