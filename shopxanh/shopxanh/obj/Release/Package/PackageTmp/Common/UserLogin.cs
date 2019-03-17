using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopxanh.Common
{
    [Serializable]
    public class UserLogin
    {
        public long userID { get; set; }
        public string UserName { get; set; }
    }
}