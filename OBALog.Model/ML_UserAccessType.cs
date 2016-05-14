using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBALog.Model
{
    public class ML_UserAccessType
    {
        public string AccessTypeName { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int Key { get; set; }
        public int UserKey { get; set; }
        public bool Deleted { get; set; }
    }
}
