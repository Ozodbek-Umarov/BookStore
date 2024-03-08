using Book.BusinessLogic.DTOs.UserDTOs;
using Book.BusinessLogic.Interfaces;
using Book.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Book.Areas.Admin.Controllers;

[Area("admin")]
[Authorize(AuthenticationSchemes = "Admin")]
public class AuthController(IAuthService authService)
        : Controller
{
    private readonly IAuthService authService = authService;

    public IActionResult Login()
    {
        LoginDto dto = new();
        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto dto)

    {
        var result = await authService.LoginAsync(dto, Role.Admin);
        if (result.IsSuccess)
        {
            return RedirectToAction("index", "home");

        }

        dto.Error = result.ErrorMessage;
        return View(dto);
    }

    public IActionResult Logout()
    {
        authService.Logout(Role.Admin);
        return RedirectToAction("login");
    }

}

