using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Book.Areas.Admin.Controllers;

[Area("admin")]
[Authorize(AuthenticationSchemes = "Admin")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Error(string url)
    {
        if (url == null)
        {
            url = "/";
        }
        return View("Error404", url);
    }
}
