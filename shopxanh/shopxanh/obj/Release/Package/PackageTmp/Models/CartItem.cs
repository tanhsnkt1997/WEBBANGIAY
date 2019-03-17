using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using model.EF;

namespace shopxanh.Areas.admin.Models
{
     [Serializable]
    public class CartItem
    {
        public Product Product { set; get; }
        public int Quantity { set; get; }
    }
}