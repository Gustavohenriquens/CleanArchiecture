using CRUD.Application.ProductDTOs;
using CRUD.Domain.ProductEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.MappingInterface
{
    public interface IProductMapper
    {
        ProductDto MapToDo(Product product);
        Product MapToEntity(CreateProductDto createDto);
        Product MapToEntity(UpdateProductDto updateDto);
    }
}
