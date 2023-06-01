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
            Console.Write("passei aqui");
            return _DataContext.product.Where(p => p.Name == name).ToList();
        }
    }
}