using Hemera.Chat.Constants;
using Hemera.Chat.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hemera.Chat.Service;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Hemera.Chat.Entities;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Hemera.Chat.API.Controllers;

[Authorize]
[Route("api/v1/[Controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;
    public readonly ILogger<ContactController> _logger;
    private readonly UserManager<ApplicationUser> _userManager;

    public ContactController(IContactService contactService, ILogger<ContactController> logger, UserManager<ApplicationUser> userManager)
    {
        _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    }

    [HttpGet]
    public async Task<IActionResult> GetContacts()
    {
        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _contactService.GetAllContacts(userId);

            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError($"GetAll users API failed! exception: {e}");

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = ResponseStatus.Error, Message = "Fetching users were fail!" });
        }
    }
}