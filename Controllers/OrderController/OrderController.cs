using Microsoft.AspNetCore.Mvc;

namespace NorSalStaff_0._1.Controllers.OrderController
{
    public class OrderController : Controller
    {
        public JsonResult Index()
        {
            return Json(new { id = 1, name = "bl777" });
        }
    }
}