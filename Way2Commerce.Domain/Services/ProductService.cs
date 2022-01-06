using Way2Commerce.Data.Models;
using Way2Commerce.Data.Models.DTOs;
using Way2Commerce.Domain.Repositories.Interfaces;

namespace Way2Commerce.Domain.Services
{
    public class ProductService
    {
        private IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<int> Insert(InsertProductDto product) 
            => await _repository.Insert(MapInsertProductDtoToProductEntity(product));

        public async Task<IEnumerable<ViewProductDto>> GetAll()
            => MapProductListToViewProductDtoList(await _repository.GetAll());

        public async Task<bool> Delete(int id)
            => await _repository.DeleteById(id);

        public async Task<int> Update(UpdateProductDto product)
            => await _repository.Update(MapUpdateProductDtoToProductEntity(product, await _repository.GetByIdNoTracking(product.Id)));

        private Product MapInsertProductDtoToProductEntity(InsertProductDto product)
            => new()
            {
                Id = 0,
                Code = product.Code,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId
            };

        private IEnumerable<ViewProductDto> MapProductListToViewProductDtoList(IEnumerable<Product> products)
            => products.Select(products => new ViewProductDto()
            {
                Id = products.Id,
                Code = products.Code,
                Name = products.Name,
                Description = products.Description,
                Price = products.Price,
                CreatedAt = products.CreatedAt,
                Category = products.Category.Name
            }).ToList();

        private Product MapUpdateProductDtoToProductEntity(UpdateProductDto productUpdate, Product productOriginal )
            => new()
            {
                Id = productUpdate.Id,
                Code = productUpdate.Code,
                Name = productUpdate.Name,
                Description = productUpdate.Description,
                Price = productUpdate.Price,
                CreatedAt = productOriginal.CreatedAt,
                CategoryId = productUpdate.CategoryId
            };
    }
}
