using Microsoft.AspNetCore.Mvc;

namespace BingSafety.Api.Controllers {
    public class ContactController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
