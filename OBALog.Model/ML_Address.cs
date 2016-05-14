using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBALog.Model
{
    public class ML_Address
    {
        public string Address { get; set; }
        public string Telephone { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int Key { get; set; }
        public int CityKey { get; set; }
        //public ML_City City { get; set; }
        public int UserKey { get; set; }
    }
}
