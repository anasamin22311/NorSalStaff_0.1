using Microsoft.AspNetCore.Mvc;

namespace NorSalStaff_0._1.Controllers.CustomerController
{
    public class CustomerController : Controller
    {
        public JsonResult Index()
        {
            return Json(new { id = 1, name = "bl7" });
        }
    }
}