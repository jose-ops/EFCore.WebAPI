
using EFCore.Dominio;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Repository
{
    public class HeroiContext : DbContext
    {
        public HeroiContext()
        {
            
        }
        public HeroiContext(DbContextOptions<HeroiContext> options) : base(options) {}

        public DbSet<Heroi> Herois { get; set; }
        public DbSet<Batalha> Batalhas { get; set; }
        public DbSet<Arma> Armas{ get; set; }
        public DbSet<HeroiBatalha> HeroisBatalhas { get; set; }
        public DbSet<IdentidadeSecreta> IdentidadesSecretas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=IdentityCurso;Data Source=DESKTOP-67GEH7I; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroiBatalha>(entity => 
            {
                entity.HasKey(e => new { e.BatalhaId, e.HeroId });
            });
        }
    }
}
