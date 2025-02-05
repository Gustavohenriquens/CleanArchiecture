using CRUD.Application.MappingInterface;
using CRUD.Application.ProductDTOs;
using CRUD.Application.UseCaseInterface;
using CRUD.Domain.RepositoryInterface;
using CRUD.Infrastructure.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.UseCasaImplementation
{
    public class ProductService(IProductRepository productRepository, IProductMapper productMapper) : IProductService
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IProductMapper _productMapper = productMapper;

        public async Task AddProductAysnc(CreateProductDto productDto)
        {
            var product = _productMapper.MapToEntity(productDto);
            await _productRepository.AddAsync(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {

                var products = await _productRepository.GetAllAsync();
                return products.Select(product => _productMapper.MapToDo(product)).ToList();
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return product == null ? null : _productMapper.MapToDo(product);
        }

        public async Task UpdateProductAysnc(UpdateProductDto productDto)
        {
            try
            {
                var product = _productMapper.MapToEntity(productDto);

                // Logando sucesso na atualização do produto
                FileLogger.ProductUpdate("Produto atualizado");

                await _productRepository.UpdateAsync(product);
            }
            catch (Exception ex)
            {
                // Logando erro ao tentar atualizar o produto
                FileLogger.ProductUpdate("Erro ao atualizar produto", ex);
            }
        }

        public async Task DeleteProductAysncAsync(int id) => await _productRepository.DeleteAsync(id);

    }
}
