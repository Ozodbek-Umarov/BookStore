using Book.BusinessLogic.DTOs.UserDTOs;
using Book.BusinessLogic.Interfaces;
using Book.BusinessLogic.Services;
using Book.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Book.Controllers;

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
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        if (loginDto == null)
        {
            return View(loginDto);
        }

        var result = await authService.LoginAsync(loginDto, Role.User);

        if (result.IsSuccess)
        {
            return RedirectToAction("Index", "Home");
        }

        return View(loginDto);
    }

    public IActionResult Register()
    {
        RegisterDto dto = new();
        return View(dto);
    }

    [HttpPost]
    public IActionResult Register(RegisterDto registerDto)
    {
        var result = authService.CreateUser(registerDto);
        if (result.IsSuccess)
        {
            return RedirectToAction("Login");
        }
        else
        {
            registerDto.ErrorMessage = result.ErrorMessage;
            return View(registerDto);
        }
    }
    public IActionResult Logout()
    {
        authService.Logout(Role.User);
        return RedirectToAction("Index", "Home");
    }


}
