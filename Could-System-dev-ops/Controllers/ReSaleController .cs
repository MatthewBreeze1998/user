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
    [Route("api/ReSale") ]
    public class ReSaleController : Controller
    {



        private ReSaleRepo _ReSaleRepo;
        public ReSaleController(ReSaleRepo ReSale)
        {
            _ReSaleRepo = ReSale;
        }
        [Route("CreateReSale/{Resale}")]
        [HttpPost]
        public async Task<ActionResult<ReSaleRepo>> CreateReSale(ReSaleModel ReSale)
        {
            _ReSaleRepo.CreateReSale(ReSale);

            return CreatedAtAction(nameof(getReSale), new { id = ReSale.ProductId}, ReSale);


        }
        [Route("GetReSale/{id}")]
        [HttpGet]
        public ActionResult<ReSaleModel> getReSale(int id)
        {
            ReSaleModel createRaSale = _ReSaleRepo.GetReSale(id);

            if(createRaSale == null)
            {
                return NotFound();
            }

            return createRaSale;
        }
        


    }
}