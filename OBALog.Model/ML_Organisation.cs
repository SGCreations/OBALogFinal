using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBALog.Model
{
    public class ML_Organisation
    {
        public string Organisation { get; set; }
        public string Website { get; set; }
        public int Key { get; set; }
        public int SubCategoryKey { get; set; }
        public int AddressKey { get; set; }
    }
}
