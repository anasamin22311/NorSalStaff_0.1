using Microsoft.AspNetCore.Mvc;

namespace NorSalStaff_0._1.Controllers.VendorController
{
    public class VendorController : Controller
    {
        public JsonResult Index()
        {
            return Json(new { id = 1, name = "bl7777" });
        }
    }
}