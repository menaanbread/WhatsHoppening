using System.Web.Mvc;
using WhatsHoppening.Infrastructure;
using WhatsHoppening.Models;

namespace WhatsHoppening.Controllers
{
    public class ProfileController : AuthenticatedController
    {
        public ProfileController(HopService hopService) : base(hopService) { }

        // GET: Profile
        public ActionResult Index()
        {
            var profileViewModel = new ProfileViewModel()
            {
                User = HopService.GetCurrentUser()
            };

            return View(profileViewModel);
        }
    }
}