using Microsoft.EntityFrameworkCore; 
namespace katmanli_mimari.Data;

public class  AppDbContext :DbContext
    {
        
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }

public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }