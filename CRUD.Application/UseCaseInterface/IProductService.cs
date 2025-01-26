using CRUD.Application.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.UseCaseInterface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto?> GetProductByIdAsync(int id);
        Task AddProductAysnc(CreateProductDto productDto);
        Task UpdateProductAysnc(UpdateProductDto productDto);
        Task DeleteProductAysncAsync(int id);
    }
}
