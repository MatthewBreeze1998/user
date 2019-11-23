using Could_System_dev_ops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Could_System_dev_ops.Repo
{
    public interface ReviewRepo

    {


        ReviewModel CreateReview(Models.ReviewModel Review);

        ReviewModel GetReReview(int id);

        IEnumerable<Models.ReviewModel> GetReview(int? ProductId, String Description);
    }
}
