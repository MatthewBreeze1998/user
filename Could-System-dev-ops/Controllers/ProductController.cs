using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Could_System_dev_ops.Models;
using Could_System_dev_ops.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Could_System_dev_ops.Controllers
{
    [Route("api/Products") ]
    public class ProductsController : Controller
    {



        private ProductsRepo _ProductsRepo;

        public ProductsController(ProductsRepo Products)
        {
            _ProductsRepo = Products;
        }
        [Route("CreatProduct/{product}")]
        [HttpPost]
        public async Task<ActionResult<ProductsModel>> CreateProdcuts(ProductsModel products)
        {

            if(products == null)
            {
                return NotFound();
            }

            _ProductsRepo.CreateProduct(products);
            return CreatedAtAction(nameof(getProducts), new { id = products.ProductId}, products);


        }
        [Route("GetProduct/{id}")]
        [HttpGet]
        public ActionResult<ProductsModel> getProducts(int id)
        {
            ProductsModel createProdcuts = _ProductsRepo.GetProduct(id);

            if(createProdcuts == null)
            {
                return NotFound();
            }

            return createProdcuts;
        }
        
        [Route("UpdateStock/{id,NewStock}")]
        [HttpPost]
        public async Task<ActionResult<ProductsModel>> UpdateStock(int id, int NewStock)
        {     
            ProductsModel Updated = _ProductsRepo.UpdateStock(id,NewStock);
            return Updated;
        }

        [Route("SetReSale/{id}")]
        [HttpPost]
        public async Task<ActionResult<ProductsModel>> SetResale(int id)
        {
            ProductsModel UpdatedPrice = _ProductsRepo.SetResale(id);
            return UpdatedPrice;

        }


    }
}