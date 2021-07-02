using System;
using System.Collections.Generic;
using EFCore4.Models;
using System.Linq;
namespace EFCore4.Services
{

    public class ProductService : IProductService
    {
        private readonly ProductContext _productContext;

        public ProductService(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public List<Product> getAll()
        {
            return _productContext.Products.ToList();
        }

        public void Create(ProductDTO productDTO)
        {
            using var transaction = _productContext.Database.BeginTransaction();

            try{
                var newProduct = new Product{
                    ProductName = productDTO.ProductName,
                    Manifacture = productDTO.Manifacture,
                    CategoryId = productDTO.CategoryId,
                };

                _productContext.Products.Add(newProduct);
                _productContext.SaveChanges();
                transaction.Commit();
            }
            catch(Exception ){
                
            }
            
        }
        public bool Update(int id, ProductDTO productDTO)
        {
            using var transaction = _productContext.Database.BeginTransaction();

            var productUpdate = _productContext.Products.Find(id);
            productUpdate.ProductName = productDTO.ProductName;
            productUpdate.Manifacture = productDTO.Manifacture;

            //case not found category id
            var checkProduct = _productContext.Categories.Find(productDTO.CategoryId);
            if(checkProduct == null){
                return false;
            }
            productUpdate.CategoryId = productDTO.CategoryId;
            _productContext.SaveChanges();
            transaction.Commit();
            return true;
        }

        public void Delete(int id)
        {
            var deleteProduct = _productContext.Products.Find(id);
            _productContext.Remove(deleteProduct);
            _productContext.SaveChanges();
        }

    }
}