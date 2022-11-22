using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotApiCalls.Properties
{
    public interface IProductsManager
    {
        //Getting all products
        List<Product> GetProducts();

        /// <summary>
        /// Add a product using a product Object.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Product AddProduct(Product product);
    }
}
