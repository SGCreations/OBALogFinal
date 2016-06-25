
namespace OBALog.Business
{
    public class BL_Profession
    {
        public int insert(OBALog.Model.ML_Profession profession)
        {
            return new OBALog.Data.DL_Profession().insert(profession);
        }

        public bool update(OBALog.Model.ML_Profession profession)
        {
            return new OBALog.Data.DL_Profession().update(profession);
        }

        public System.Data.DataTable select(OBALog.Model.ML_Profession profession)
        {
            return new OBALog.Data.DL_Profession().select(profession);
        }

        public int selectUsage(OBALog.Model.ML_Profession profession)
        {
            return new OBALog.Data.DL_Profession().selectUsage(profession);
        }

        public bool delete(OBALog.Model.ML_Profession profession)
        {
            return new OBALog.Data.DL_Profession().delete(profession);
        }
    }
}
