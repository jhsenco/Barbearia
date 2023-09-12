using Barbearia.Data.Map;
using Barbearia.Models;
using Microsoft.EntityFrameworkCore;

namespace Barbearia.Data
{

    // : sinal de herança
    public class BarbeariaDBContex : DbContext
    {
        public BarbeariaDBContex(DbContextOptions<BarbeariaDBContex> options)
            : base(options)
        { 
        }

        public DbSet<BarbeiroModel> Barbeiros { get; set;}
        public DbSet<ServicoModel> Servicos { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BarbeiroMap());
            modelBuilder.ApplyConfiguration(new ServicoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
