using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.DAL
{
    public class DataAcessLayer
    {
        public static InventoryWebApiEntities DbContext { get; private set; }
        public DataAcessLayer()
        {
            DbContext = new InventoryWebApiEntities();
        }


        public List<Product> GetAllProducts()
        {
            return DbContext.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return DbContext.Products.FirstOrDefault(p => p.ProductId == id);
        }


        public bool InsertProduct(Product productItem)
        {
            bool status;
            try
            {
                DbContext.Products.Add(productItem);
                DbContext.SaveChanges();
                status = true;
            }
            catch (Exception )
            {
                status = false;
            }

            return status;
        }


        public bool UpdateProduct(Product productItem)
        {
            bool status;
            try
            {
                var product = DbContext.Products.FirstOrDefault(p => p.ProductId == productItem.ProductId);
                if (product != null)
                {
                    product.ProductName = productItem.ProductName;
                    product.Quantity = productItem.Quantity;
                    product.Price = productItem.Price;
                }
                DbContext.SaveChanges();
                status = true;
            }
            catch (Exception )
            {
                status = false;
            }
            return status;
        }

        public bool DeleteProduct(int id)
        {
            bool status;
            try
            {
                var productItem = DbContext.Products.FirstOrDefault(p => p.ProductId == id);
                if (productItem != null)
                {
                    DbContext.Products.Remove(productItem);
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}
