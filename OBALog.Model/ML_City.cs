using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBALog.Model
{
    class ML_City
    {
        public string City { get; set; }
        public int Key { get; set; }
        //public ML_Country Country { get; set; }
        public int CountryKey { get; set; }
    }
}
