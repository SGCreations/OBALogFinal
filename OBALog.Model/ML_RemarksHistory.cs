using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBALog.Model
{
    public class ML_RemarksHistory
    {
        public string MembershipNo { get; set; }
        public string Remarks { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int Key { get; set; }
        public int UserKey { get; set; }
    }
}
