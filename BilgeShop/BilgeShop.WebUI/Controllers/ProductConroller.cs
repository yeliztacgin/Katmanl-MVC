using Microsoft.AspNetCore.Mvc;

namespace BilgeShop.WebUI.Controllers
{
    public class ProductConroller : Controller
    {
        public IActionResult Detail(int id)
        {
            return View();
        }
    }
}
