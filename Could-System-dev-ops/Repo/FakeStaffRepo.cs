using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Could_System_dev_ops.Models;

namespace Could_System_dev_ops.Repo
{
    public class FakeStaffRepo : StaffRepo

    {

        private List<StaffModel> _staffModelsList;

        public FakeStaffRepo()
        {
            _staffModelsList = new List<StaffModel>()
            {
                new StaffModel() {StaffId = 1,FirstName = "cameron", LastName = "charlton", ContactNumebr = 198237129, Email = "cam_puto@hotmail.co.uk", PayRoll = 23123123},
                new StaffModel() {StaffId = 2,FirstName = "sam", LastName = "el", ContactNumebr = 192342123429, Email = "sma_fecal@hotmail.co.uk", PayRoll = 2325243},
                new StaffModel() {StaffId = 1,FirstName = "josh", LastName = "white", ContactNumebr = 11212213129, Email = "josh_white@hotmail.co.uk", PayRoll =12533123}
            };
        }
            


            

        public StaffModel CreateStaff(StaffModel staff)
        {
            _staffModelsList.Add(staff);
            return staff;
        }

        public StaffModel GetStaff(int id)
        {
            return _staffModelsList.FirstOrDefault(x => id == x.StaffId);
        }

        public IEnumerable<StaffModel> GetStaff(int? StaffId, string FirstName, string LastName, string Email, double? ContactNumebr, double? PayRoll)
        {
            throw new NotImplementedException();
        }
    }
}
