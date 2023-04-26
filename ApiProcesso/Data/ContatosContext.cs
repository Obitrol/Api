using ApiProcesso.Data.Map;
using ApiProcesso.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiProcesso.Data
{
    public class ContatosContext : DbContext
    {
        public ContatosContext(DbContextOptions<ContatosContext> options)
            : base(options)
        {

        }
        public DbSet<ContatoModel> Contatos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
