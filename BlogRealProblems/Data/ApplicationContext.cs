using BlogRealProblems.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{     
        public ApplicationContext(DbContextOptions<ApplicationContext> opts) : base(opts) { }
        public DbSet<Noticia> Noticias { get; set; }


}
