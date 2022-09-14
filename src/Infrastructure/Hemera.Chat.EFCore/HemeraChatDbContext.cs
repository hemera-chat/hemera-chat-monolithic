using Hemera.Chat.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hemera.Chat.EFCore;
public class HemeraChatDbContext : IdentityDbContext
{
    public HemeraChatDbContext(DbContextOptions<HemeraChatDbContext> options) : base(options)
    {

    }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Message> Messages { get; set; }
}
