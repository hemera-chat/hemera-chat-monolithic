using AutoMapper;
using Hemera.Chat.Dtos;
using Hemera.Chat.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hemera.Chat.Service
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private UserManager<ApplicationUser> _userManager;

        public ContactService(IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<List<ContactInfoDto>> GetAllContacts(string currentUser)
        {
            var users = await _userManager.Users.ToListAsync();

            return _mapper.Map<List<ContactInfoDto>>(users);
        }

        public List<ContactInfoDto> GetContactByUserId(string userId)
        {
            var users = _userManager.Users.ToList();
            var contactInfos = _mapper.Map<List<ContactInfoDto>>(users);
            return contactInfos;
        }
    }
}
