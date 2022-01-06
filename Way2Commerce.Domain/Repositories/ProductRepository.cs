using Microsoft.EntityFrameworkCore;
using Way2Commerce.Data.Contexts;
using Way2Commerce.Data.Models;
using Way2Commerce.Domain.Repositories.Interfaces;

namespace Way2Commerce.Domain.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private DatabaseContext _context;

        public ProductRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteById(int id)
        {
            var product = new Product() { Id = id };
            _context.Products.Attach(product);
            _context.Products.Remove(product);
            var count = await _context.SaveChangesAsync();
            return count > 0;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return _context.Products.Join(
                _context.Categories,
                product => product.CategoryId,
                category => category.Id,
                (product, category) => new Product()
                {
                    Id = product.Id,
                    Code = product.Code,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    CreatedAt = product.CreatedAt,
                    CategoryId = category.Id,
                    Category = category
                }).ToList();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<int> Insert(Product entity)
        {
            var result = await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task<int> Update(Product entity)
        {
            _context.Products.Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<Product> GetByIdNoTracking(int id)
        {
            return await _context.Products.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);
        }
    }
}
