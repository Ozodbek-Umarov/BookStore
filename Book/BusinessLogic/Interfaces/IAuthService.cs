using Book.BusinessLogic.Common;
using Book.BusinessLogic.DTOs.UserDTOs;
using Book.Data.Entities;

namespace Book.BusinessLogic.Interfaces;

public interface IAuthService
{
    Task<AuthResult> LoginAsync(LoginDto loginDto, Role kim);
    AuthResult CreateUser(RegisterDto registerDto);
    bool IsLoggedIn();
    void Logout(Role kim);
    string GetFullName(Role kim);
    string GetPhoneNumber(Role kim);
}
