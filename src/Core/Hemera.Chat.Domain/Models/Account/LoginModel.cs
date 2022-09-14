namespace Hemera.Chat.Models;
public class LoginModel
{
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string Password { get; set; } = default!;
}