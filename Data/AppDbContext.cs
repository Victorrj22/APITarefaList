using Microsoft.EntityFrameworkCore;

namespace ApiList.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Atividades> Atividade { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
    }


}