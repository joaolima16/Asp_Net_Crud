using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
namespace api.Repository
{
    public class ProductActions : IProduct
    {
        private DataContext _DataContext ;
        public ProductActions(DataContext dataContext) => _DataContext = dataContext;


        public ProductModel addProduct(ProductModel product)
        {
            _DataContext.product.Add(product);  
            _DataContext.SaveChanges();
            return product;  
        }
        public List<ProductModel> products()
        {
                return _DataContext.product.ToList();
        }

        public List<ProductModel> product(string name)
        {
            return _DataContext.product.Where(p => p.Name == name).ToList();
        }

        public ProductModel updateProduct(string name,ProductModel product)
        {
            var _product = _DataContext.product.FirstOrDefault(p => p.Name == name);
            _product.Name = product.Name;
            _product.Value = product.Value;
            _DataContext.SaveChanges();
            return _product;

        }

        public ProductModel deleteProduct(string name)
        {
            var _product = _DataContext.product.First(p => p.Name == name);
            _DataContext.product.Remove(_product);
            _DataContext.SaveChanges();
            return _product;

        }
    }
}