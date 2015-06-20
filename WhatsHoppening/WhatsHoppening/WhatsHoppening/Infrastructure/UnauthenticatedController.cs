using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatsHoppening.Domain.Interfaces;

namespace WhatsHoppening.Infrastructure
{
    public class UnauthenticatedController : Controller
    {
        private HopCore core = null;

        public UnauthenticatedController(HopCore core)
        {
            this.core = core;
        }

        public HopCore Core { get { return core; } internal set { core = value; } }

        public ILogger Log { get { return core.Logger; } }
    }
}