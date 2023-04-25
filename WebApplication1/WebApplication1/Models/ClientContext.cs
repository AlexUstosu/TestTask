using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace Clients.Models;

public class ClientContext : DbContext
{
    public ClientContext(DbContextOptions<ClientContext> options)
        : base(options)
    {
    }

    public DbSet<Client> ClientsItem { get; set; } = null!;
}