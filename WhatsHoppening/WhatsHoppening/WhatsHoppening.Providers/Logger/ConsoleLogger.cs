using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHoppening.Domain.Interfaces;

namespace WhatsHoppening.Providers.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void Log(Domain.LogSeverity logSeverity, string message)
        {
            throw new NotImplementedException();
        }

        public void Log(Domain.LogSeverity logSeverity, string message, Exception e)
        {
            throw new NotImplementedException();
        }
    }
}
