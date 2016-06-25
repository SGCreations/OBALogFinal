using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBALog.Business
{
    public class BL_OrganisationCategory
    {
        public int insert(OBALog.Model.ML_OrganisationCategory category)
        {
            return new OBALog.Data.DL_OrganisationCategory().insert(category);
        }

        public bool update(OBALog.Model.ML_OrganisationCategory category)
        {
            return new OBALog.Data.DL_OrganisationCategory().update(category);
        }

        public System.Data.DataTable select(OBALog.Model.ML_OrganisationCategory category)
        {
            return new OBALog.Data.DL_OrganisationCategory().select(category);
        }

        public int selectUsage(OBALog.Model.ML_OrganisationCategory category)
        {
            return new OBALog.Data.DL_OrganisationCategory().selectUsage(category);
        }

        public bool delete(OBALog.Model.ML_OrganisationCategory category)
        {
            return new OBALog.Data.DL_OrganisationCategory().delete(category);
        }
    }
}
