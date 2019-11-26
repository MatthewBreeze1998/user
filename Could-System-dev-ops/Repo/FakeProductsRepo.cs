using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Could_System_dev_ops.Models;

namespace Could_System_dev_ops.Repo
{
    public class FakeProductsRepo : ProductsRepo

    {

        private List<ProductsModel> _ProductsModelsList;

        public FakeProductsRepo()
        {
            _ProductsModelsList = new List<ProductsModel>()
            {
                new ProductsModel() {ProductId = 1,ProductName = "levi jeans", Description  =  "blue Jeans", StockLevel = 19},
                new ProductsModel() {ProductId = 1,ProductName = "Black desk", Description  =  "Black desk", StockLevel = 3},
                new ProductsModel() {ProductId = 1,ProductName = "Moniter", Description  =  "24' lg 1080p", StockLevel = 19}
            };
        }

        public ProductsModel CreateProduct(ProductsModel products)
        {
            _ProductsModelsList.Add(products);
            return products;
        }

        public ProductsModel GetProduct(int id)
        {
            return _ProductsModelsList.FirstOrDefault(x => id == x.ProductId);
        }

        public IEnumerable<ProductsModel> GetProduct(int? ProductId, string ProdcutName, string Description, int? Stocklevel)
        {
            return _ProductsModelsList.AsEnumerable<ProductsModel>();
        }
    }
}
