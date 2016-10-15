using OBALog.Data;

namespace OBALog.Business
{
  public  class BL_UsageLog
    {
        public int insert(OBALog.Model.ML_UsageLog UsageLog)
        {
            return new DL_UsageLog().insert(UsageLog);
        }

        public System.Data.DataTable selectAll()
        {
            return new DL_UsageLog().selectAll();
        }

        public System.Data.DataTable selectByUser(OBALog.Model.ML_UsageLog UsageLog,int RowCount)
        {
            return new DL_UsageLog().selectByUser(UsageLog, RowCount);
        }

        public bool update(OBALog.Model.ML_UsageLog UsageLog)
        {
            return new DL_UsageLog().update(UsageLog);
        }

        public bool delete(OBALog.Model.ML_UsageLog UsageLog)
        {
            return new DL_UsageLog().delete(UsageLog);
        }
    }
}
