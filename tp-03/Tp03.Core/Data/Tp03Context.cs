using Microsoft.EntityFrameworkCore;
using Tp03.Core.Entities;

namespace Tp03.Core.Data
{
  public class Tp03Context : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
      options.UseSqlite(
        "Data Source=./my-beautiful-maintenable-secret-high-level-of-knowledge-and-scalable-sql-database.db"
      );

    public virtual DbSet<Container> Containers { get; set; }
    public virtual DbSet<BillOfLading> BillsOfLading { get; set; }
  }
}
