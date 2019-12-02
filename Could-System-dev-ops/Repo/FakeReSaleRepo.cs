using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Could_System_dev_ops.Models;

namespace Could_System_dev_ops.Repo
{
    public class FakeReSaleRepo : ReSaleRepo

    {

        private List<ReSaleModel> _ReSaleModelList;

        private List<ProductsModel> _productsList;
        public FakeReSaleRepo()
        {
            _ReSaleModelList = new List<ReSaleModel>()
            {
                new ReSaleModel() {ProductId = 1,CurrentPrice = 123.12, NewPrice = 110.42, },
                new ReSaleModel() {ProductId = 2,CurrentPrice= 11.4, NewPrice = 9.42, },
                new ReSaleModel() {ProductId = 2,CurrentPrice = 341.41, NewPrice = 310.42,}
            };
        }

        public ReSaleModel CreateReSale(ReSaleModel ReSale)
        {
            _ReSaleModelList.Add(ReSale);
            return ReSale;
        }

        public ReSaleModel GetReSale(int id)
        {
            return _ReSaleModelList.FirstOrDefault(x => id == x.ProductId);
        }

        public IEnumerable<ReSaleModel> GetReSale(int? ProductId, Double? CurrentPrice, Double? NewPrice)
        {
            return _ReSaleModelList.AsEnumerable<ReSaleModel>();
        }

        
    }
}
