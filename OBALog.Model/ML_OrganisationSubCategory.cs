using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBALog.Model
{
    public class ML_OrganisationSubCategory
    {
        public string SubCategory { get; set; }
        public int Key { get; set; }
        //public int CategoryKey { get; set; }
        public ML_OrganisationCategory Category { get; set; }
    }
}
