using Could_System_dev_ops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Could_System_dev_ops.Repo
{
    public interface ReSaleRepo

    {

        ReSaleModel CreateReSale(Models.ReSaleModel ReSale);

        ReSaleModel GetReSale(int id);

        IEnumerable<Models.ReSaleModel> GetReSale(int? ProductId, Double? CurrentPrice, Double? NewPrice);

        
    }
}
