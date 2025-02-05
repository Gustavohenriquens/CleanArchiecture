using CRUD.Domain.ProductEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Infrastructure.DatabaseContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public AppDbContext()
        {
            
        }

        public DbSet<Product> Products { get; set; }
    


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Configuração para uso em tempo de design
                optionsBuilder.UseSqlServer("Server=DESKTOP-9DV2CSG\\SQL_GUSTAVO;Database=BancoDados;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}
