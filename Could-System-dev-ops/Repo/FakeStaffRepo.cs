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
                new StaffModel() {StaffId = 3,FirstName = "josh", LastName = "white", ContactNumebr = 11212213129, Email = "josh_white@hotmail.co.uk", PayRoll =12533123}
            };
        }
           
        public StaffModel CreateStaff(StaffModel staff)
        {
            _staffModelsList.Add(staff);
            return staff;
        }

        public StaffModel DeleteStaff(int id)
        {
            StaffModel Remove = _staffModelsList.FirstOrDefault(x => id == x.StaffId);
            _staffModelsList.Remove(_staffModelsList.FirstOrDefault(x => id == x.StaffId));
            return Remove;

        }

        public StaffModel GetStaff(int id)
        {
            return _staffModelsList.FirstOrDefault(x => id == x.StaffId);
        }

        public IEnumerable<StaffModel> GetStaff(int? StaffId, string FirstName, string LastName, string Email, double? ContactNumebr, double? PayRoll)
        {
            return _staffModelsList.AsEnumerable<StaffModel>();
        }

        private List<UsersModel> _UserList;
        public UsersModel SetPurchaseAbility(int id)
        {    
            UsersModel activity = _UserList.FirstOrDefault(x => id == x.UserId);

            activity.PurchaseAbility = !activity.PurchaseAbility;
            _UserList.Insert(_UserList.IndexOf(_UserList.FirstOrDefault(x => id == x.UserId)), activity);
            return activity;
        }

        public StaffModel EditStaff(StaffModel staff)
        {
            _staffModelsList[_staffModelsList.IndexOf(_staffModelsList.FirstOrDefault(x => x.StaffId == staff.StaffId))] = staff;
            return staff;
        }
    }
}
