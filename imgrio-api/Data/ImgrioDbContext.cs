using imgrio_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace imgrio_api.Data
{
    public class ImgrioDbContext : DbContext
    {
        public DbSet<UserContent> UserContents { get; set; }

        public ImgrioDbContext(DbContextOptions options) : base(options) { }
    }
}
