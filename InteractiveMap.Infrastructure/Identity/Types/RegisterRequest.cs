namespace InteractiveMap.Infrastructure.Identity.Types;

public class RegisterRequest
{
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
