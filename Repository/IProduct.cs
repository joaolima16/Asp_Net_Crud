using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Repository
{
    public interface IProduct
    {
        ProductModel addProduct(ProductModel product);
        List<ProductModel> products();
        List<ProductModel> product(string name);
        ProductModel updateProduct(string name, ProductModel product);
        ProductModel deleteProduct(string name);

    }
}