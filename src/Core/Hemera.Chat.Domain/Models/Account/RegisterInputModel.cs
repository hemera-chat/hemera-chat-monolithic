namespace Hemera.Chat.Models
{
    public class RegisterModel
    {
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;
        public bool IsOnline { get; set; } = false;
    }
}
