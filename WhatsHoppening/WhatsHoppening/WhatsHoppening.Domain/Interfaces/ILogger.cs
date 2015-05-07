using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHoppening.Domain.Interfaces
{
    public interface ILogger
    {
        void Log(LogSeverity logSeverity, string message);
        void Log(LogSeverity logSeverity, string message, Exception e);
    }
}
