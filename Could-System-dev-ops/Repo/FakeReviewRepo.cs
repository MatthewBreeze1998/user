using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Could_System_dev_ops.Models;

namespace Could_System_dev_ops.Repo
{
    public class FakeReviewRepo : ReviewRepo

    {

        private List<ReviewModel> _ReviewlList;

        public FakeReviewRepo()
        {
            _ReviewlList = new List<ReviewModel>()
            {
                new ReviewModel() {ProductId = 1,Review = "GREATE", },
                new ReviewModel() {ProductId = 1,Review = "MEH", },
                new ReviewModel() {ProductId = 1,Review = "Hate It",}
            };
        }


        public ReviewModel CreateReview(ReviewModel Review)
        {
            _ReviewlList.Add(Review);
            return Review;
        }

        public ReviewModel GetReReview(int id)
        {
            return _ReviewlList.FirstOrDefault(x => id == x.ProductId);
        }

        public IEnumerable<ReviewModel> GetReview(int? ProductId, String Description)
        {
            throw new NotImplementedException();
        }
    }
}
