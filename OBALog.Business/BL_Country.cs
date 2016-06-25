
namespace OBALog.Business
{
    public class BL_Country
    {
        public int insert(OBALog.Model.ML_Country country)
        {
            return new OBALog.Data.DL_Country().insert(country);
        }

        public bool update(OBALog.Model.ML_Country country)
        {
            return new OBALog.Data.DL_Country().update(country);
        }

        public System.Data.DataTable select(OBALog.Model.ML_Country country)
        {
            return new OBALog.Data.DL_Country().select(country);
        }

        public int selectUsage(OBALog.Model.ML_Country country)
        {
            return new OBALog.Data.DL_Country().selectUsage(country);
        }

        public bool delete(OBALog.Model.ML_Country country)
        {
            return new OBALog.Data.DL_Country().delete(country);
        }
    }
}
