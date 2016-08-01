using System.Data;

namespace OBALog.Business
{
    public class BL_Configurations
    {
        public bool update(OBALog.Model.ML_Configurations config)
        {
            return new OBALog.Data.DL_Configurations().update(config);
        }



        public DataTable select()
        {
            return new OBALog.Data.DL_Configurations().select();
        }
    }
}
