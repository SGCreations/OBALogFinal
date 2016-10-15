using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBALog.Windows
{
    [System.Diagnostics.DebuggerStepThrough()]
    public static class UniversalEnum
    {
        public enum MessageTypes
        {
            Success,
            Error,
            Information,
            Warning,
            YesNo,
            YesNoCancel,
            Exclamation
        }
    }
}
