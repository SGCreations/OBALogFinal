
namespace OBALog.Business
{
    public class BL_City
    {
        public int insert(OBALog.Model.ML_City city)
        {
            return new OBALog.Data.DL_City().insert(city);
        }

        public bool update(OBALog.Model.ML_City city)
        {
            return new OBALog.Data.DL_City().update(city);
        }

        public System.Data.DataTable selectByCountry(OBALog.Model.ML_City city)
        {
            return new OBALog.Data.DL_City().selectByCountry(city);
        }

        public int selectUsage(OBALog.Model.ML_City city)
        {
            return new OBALog.Data.DL_City().selectUsage(city);
        }

        public bool delete(OBALog.Model.ML_City city)
        {
            return new OBALog.Data.DL_City().delete(city);
        }

        public bool deleteByCountry(Model.ML_City city)
        {
            return new OBALog.Data.DL_City().deleteByCountry(city);
        }

        public System.Data.DataTable select(Model.ML_City city)
        {
            return new OBALog.Data.DL_City().select(city);

        }
    }
}
