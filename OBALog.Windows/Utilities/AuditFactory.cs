using System;
using System.Diagnostics;
using System.IO;

namespace OBALog.Windows
{
    [System.Diagnostics.DebuggerStepThrough()]
    public static class AuditFactory
    {
        public static void AuditLog(Exception exception)
        {
            try
            {
                StackTrace stackTrace = new StackTrace();
                var ErrorText = string.Format("{0} {1} {2} {3} {4}", DateTime.Now, exception.Message, stackTrace.GetFrame(1).GetMethod().DeclaringType.Name, stackTrace.GetFrame(1).GetMethod().Name, exception.StackTrace);

                LogWriter(ErrorText);
            }
            catch (Exception ex)
            {
                ApplicationUtilities.ShowMessage(UniversalEnum.MessageTypes.Error, ex.Message, "Fatal Error");
            }
        }

        public static void LogWriter(string Message)
        {
            File.AppendAllLines(string.Format("AppLog\\{0:dd-M-yyyy}.log", DateTime.Now), new[] { Message + Environment.NewLine });
        }
    }
}
