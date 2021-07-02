using EFCore4.Models;
using System.Collections.Generic;

namespace EFCore4.Services
{
    public interface IProductService{

        List<Product> getAll();
        void Create(ProductDTO productDTO);
        bool Update(int id, ProductDTO product);
        
        void Delete(int id);
    }
}