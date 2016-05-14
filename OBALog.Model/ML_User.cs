using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBALog.Model
{
    public class ML_User
    {
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string NIC { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int Key { get; set; }
        public int UserAccessTypeKey { get; set; }
        //public ML_UserAccessType UserAccessType { get; set; }
        public int UserKey { get; set; }
        public bool Deleted { get; set; }
    }
}
