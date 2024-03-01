using Book.BusinessLogic.Interfaces;
using Book.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Book.Controllers
{
    public class JanrController(IJanrService janrService)
        : Controller
    {
        private readonly IJanrService _janrService = janrService;

        public IActionResult Index()
        {
            var janrs = _janrService.GetAll();
            return View(janrs);
        }
    }
}
