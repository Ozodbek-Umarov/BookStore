namespace Book.BusinessLogic.DTOs.UserDTOs;

public class LoginDto
{
    public string PhoneNumber { get; set; } = "";
    public string Password { get; set; } = "";

    public bool RememberMe { get; set; }
    public string Error { get; set; } = "";
}
