using System.Data.Entity;
using Teste_MVC_FranciscoBispo.Models;

namespace Teste_MVC_FranciscoBispo.Context;

public class ApplicationDbContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
}
