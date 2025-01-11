using Microsoft.EntityFrameworkCore;
using YemekBlog.Models;

namespace YemekBlog.Models // Data yerine Models namespace'i kullanabilirsiniz
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Tarif> Tarifler { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }
    }
}
