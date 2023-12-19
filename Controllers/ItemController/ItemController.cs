using Microsoft.AspNetCore.Mvc;
namespace NorSalStaff_0._1.Controllers.ItemController
{
    public class ItemController : Controller
    {
        public JsonResult Index()
        {
            return Json(new { id = 1, name = "bl77" });
        }
    }
}