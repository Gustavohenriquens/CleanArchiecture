using CRUD.Domain.ProductEntity;
using CRUD.Domain.RepositoryInterface;
using CRUD.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Infrastructure.RepositoryImplementation
{
    public class ProductRepository(AppDbContext context) : IProductRepository
    {
        private readonly AppDbContext _context = context;

        public async Task AddAsync(Product product)
        {
           await _context.Products.AddAsync(product);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null) 
            { 
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync() => 
            await _context.Products.AsNoTracking().ToListAsync();

        public async Task<Product?> GetByIdAsync(int id) =>
            await _context.Products.FindAsync(id);

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
