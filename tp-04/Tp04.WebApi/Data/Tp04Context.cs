using Microsoft.EntityFrameworkCore;
using Tp04.WebApi.Entities;

namespace Tp04.WebApi.Data
{
  public class Tp04Context : DbContext
  {
    public DbSet<Livro> Livros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=tp_04.db");
    }
  }
}
