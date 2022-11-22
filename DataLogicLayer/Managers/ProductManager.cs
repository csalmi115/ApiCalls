using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotApiCalls.Managers
{
    internal class ProductManagerFakeDB : Properties.IProductManager
    {
        private int id = 1;
        List<Product> productFakeDB = new List<Product>();

        public ProductManagerFakeDB()
        {
            AddProduct(new Product() { productCode_code = "O1000C" , ProductName = "Pile" });
            AddProduct(new Product() { productCode_code = "O1000C" , ProductName = "Pip" });
        }

        public List<Product> GetProducts()
        {
            return productFakeDB;
        }

        public Product AddProduct(Product product)
        {
            Product addedProduct;
            productFakeDB.Add(addedProduct = new Product()
            {
                productCode_code = product.productCode_code
                //productName = product.ProductName
            });
            addedProduct.Id = id++;
            return addedProduct;
        }

    }
}
