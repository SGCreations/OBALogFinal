using System.Data;

namespace OBALog.Business
{
    public class BL_Organisation
    {
        public int insert(OBALog.Model.ML_Organisation organisation)
        {
            return new OBALog.Data.DL_Organisation().insert(organisation);
        }

        public bool update(OBALog.Model.ML_Organisation organisation)
        {
            return new OBALog.Data.DL_Organisation().update(organisation);
        }

        public DataTable select(OBALog.Model.ML_Organisation organisation)
        {
            return new OBALog.Data.DL_Organisation().select(organisation);
        }
        public DataTable selectNewRecord(OBALog.Model.ML_Organisation organisation)
        {
            return new OBALog.Data.DL_Organisation().selectNewRecord(organisation);
        }

        public int selectUsage(OBALog.Model.ML_Organisation organisation)
        {
            return new OBALog.Data.DL_Organisation().selectUsage(organisation);
        }

        public bool delete(OBALog.Model.ML_Organisation organisation)
        {
            return new OBALog.Data.DL_Organisation().delete(organisation);
        }
    }
}
