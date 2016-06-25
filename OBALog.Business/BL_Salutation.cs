
namespace OBALog.Business
{
   public class BL_Salutation
   {
       public int insert(OBALog.Model.ML_Salutation salutation)
       {
           return new OBALog.Data.DL_Salutation().insert(salutation);
       }

       public bool update(OBALog.Model.ML_Salutation salutation)
       {
           return new OBALog.Data.DL_Salutation().update(salutation);
       }

       public System.Data.DataTable select(OBALog.Model.ML_Salutation salutation)
       {
           return new OBALog.Data.DL_Salutation().select(salutation);
       }

       public int selectUsage(OBALog.Model.ML_Salutation salutation)
       {
           return new OBALog.Data.DL_Salutation().selectUsage(salutation);
       }

       public bool delete(OBALog.Model.ML_Salutation salutation)
       {
           return new OBALog.Data.DL_Salutation().delete(salutation);
       }
    }
}
