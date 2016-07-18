
namespace OBALog.Business
{
    public class BL_Address
    {

        public int insert(OBALog.Model.ML_Address address)
        {
            return new OBALog.Data.DL_Address().insert(address);
        }

        public bool update(OBALog.Model.ML_Address address)
        {
            return new OBALog.Data.DL_Address().update(address);
        }

        public System.Data.DataTable select(OBALog.Model.ML_Address address)
        {
            return new OBALog.Data.DL_Address().select(address);
        }

        public bool delete(OBALog.Model.ML_Address address)
        {
            return new OBALog.Data.DL_Address().delete(address);
        }
    }
}
