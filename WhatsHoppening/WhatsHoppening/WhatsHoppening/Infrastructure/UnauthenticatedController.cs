using System.Web.Mvc;
using WhatsHoppening.Domain.Interfaces;

namespace WhatsHoppening.Infrastructure
{
    public class UnauthenticatedController : Controller
    {
        private HopService _hopService = null;

        public UnauthenticatedController(HopService hopService)
        {
            _hopService = hopService;

            _hopService.CreateSession();
        }

        public HopService HopService
        {
            get
            {
                return _hopService;
            }
            internal set
            {
                _hopService = value;
            }
        }

        public ILogger Log { get { return _hopService.Logger; } }
    }
}