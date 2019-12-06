using Could_System_dev_ops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Could_System_dev_ops.Repo
{
    public interface StaffRepo

    {
        StaffModel DeleteStaff(int id);


        StaffModel CreateStaff(Models.StaffModel staff);

        StaffPermissonsModel GetStaffPermissions(int id);

        IEnumerable<Models.StaffPermissonsModel> GetStaffPermissions(int? StaffId, Boolean CanDeleteUser, Boolean CanHideReview, Boolean SetPurchaseAbility,Boolean ViewUsers, Boolean ViewOrderList, Boolean ViewPendingOrders, Boolean ViewSetReSale, Boolean PurchaseRequest, Boolean ViewStocklevel, Boolean AddStaff, Boolean RemoveStaff, Boolean authorisePermissons, Boolean ApproveStaffPurchase);

        StaffModel GetStaff(int? id);

        UsersModel SetPurchaseAbility(int id);

        IEnumerable<Models.StaffModel> GetStaffAll();

        StaffModel EditStaff(StaffModel staff);

    }
}
