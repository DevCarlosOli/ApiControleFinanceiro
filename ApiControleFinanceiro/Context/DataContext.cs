using ApiControleFinanceiro.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ApiControleFinanceiro.Context
{
    public class DataContext : DbContext
    {
        public DbSet<CategoriaEntity> Categorias { get; set; }
        public DbSet<SubcategoriaEntity> Subcategorias { get; set; }
        public DbSet<LancamentoEntity> Lancamentos { get; set; }

        public DataContext(DbContextOptions<DataContext> options) 
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            optionsBuilder.UseNpgsql(configuration.GetConnectionString("ApiConnection"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CategoriaEntity>().Property(c => c.IdCategoria).UseIdentityAlwaysColumn();
            builder.Entity<CategoriaEntity>().HasIndex(c => c.Nome).IsUnique();
            builder.Entity<SubcategoriaEntity>().Property(c => c.IdSubcategoria).UseIdentityAlwaysColumn();
            builder.Entity<SubcategoriaEntity>().HasIndex(c => c.Nome).IsUnique();
            builder.Entity<LancamentoEntity>().Property(c => c.IdLancamento).UseIdentityAlwaysColumn();
        }
    }
}
