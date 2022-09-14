using Hemera.Chat.Dtos;

namespace Hemera.Chat.Service;
public interface IContactService
{
    List<ContactInfoDto> GetContactByUserId(string userId);
    Task<List<ContactInfoDto>> GetAllContacts(string currentUser);
}