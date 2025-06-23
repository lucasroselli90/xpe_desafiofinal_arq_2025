using Microsoft.EntityFrameworkCore;
using XpeClienteApi.Models;

namespace XpeClienteApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Cliente> Clientes => Set<Cliente>();
}
