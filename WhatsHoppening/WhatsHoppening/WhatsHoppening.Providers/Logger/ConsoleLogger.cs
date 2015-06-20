using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHoppening.Domain;
using WhatsHoppening.Domain.Interfaces;
using WhatsHoppening.Extensions;

namespace WhatsHoppening.Providers.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void Log(LogSeverity logSeverity, string message)
        {
            Debug.Print("{0} - {1}".FormatWith(logSeverity.ToString("G"), message));
        }

        public void Log(LogSeverity logSeverity, string message, Exception e)
        {
            Debug.Print("{0} - {1}. Logged message {2}.".FormatWith(logSeverity.ToString("G"), message, e.Message));
        }
    }
}
