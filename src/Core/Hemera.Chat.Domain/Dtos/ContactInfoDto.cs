namespace Hemera.Chat.Dtos;

public class ContactInfoDto
{
    public string UserName { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? ProfileAvatarPath { get; set; }
    public string Id { get; set; } = default!;
}
