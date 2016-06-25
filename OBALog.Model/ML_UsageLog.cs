using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBALog.Model
{
    public class ML_UsageLog
    {
        public int Key { get; set; }
        public int UserKey { get; set; }
        public DateTime To { get; set; }
        public DateTime From { get; set; }
    }
}
