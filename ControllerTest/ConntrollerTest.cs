using Could_System_dev_ops.Controllers;
using Could_System_dev_ops.Models;
using Could_System_dev_ops.Repo;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace ControllerTest
{
    public class UserControllerTest
    {
        private HttpClient _client;
        private UserRepo _userRepo;
        private UserController _userController;
        private List<UsersModel> _UserTestData;

        public UserControllerTest()
        {
            _client = new HttpClient();
        }

        [SetUp]
        public void Setup()
        {
            _UserTestData = new List<UsersModel>()
            {
                new UsersModel() { UserId = 1, FirstName = "cameron", LastName = "charlton", Email = "charlton98@gmail.com", isActive = true, PurchaseAbility = true },
                new UsersModel() { UserId = 2, FirstName = "Shaun", LastName = "andrew", Email = "shaun_andrew@hotmail.com", isActive = false, PurchaseAbility = false },
                new UsersModel() { UserId = 3, FirstName = "danielle", LastName = "houston", Email = "Danielle@outlook.com", isActive = true, PurchaseAbility = false }
            };

            _userRepo = new FakeUserRepo();
            _userController = new UserController(_userRepo);
        }

        [Test]
        public void CreateUser_validUser_ShouldObject()
        {
            
             
            Assert.IsNotNull(_userRepo);
            Assert.IsNotNull(_userController);
            UsersModel user = new UsersModel() { UserId = 4, FirstName = "Stella", LastName = "jones", Email = "Stella_jones@gmail.com", isActive = true, PurchaseAbility = true };
            Assert.IsNotNull(user);

            int currentMaxId = _userController.GetAllUsers().Max(x => x.UserId);
            Assert.GreaterOrEqual(currentMaxId, 1);


            ActionResult<UsersModel> result = _userController.CreateUser(user);
            Assert.IsNotNull(result);

            ActionResult usersResult = result.Result;
            Assert.AreEqual(usersResult.GetType(), typeof(CreatedAtActionResult));

            CreatedAtActionResult createdUserResult = (CreatedAtActionResult)usersResult;
            Assert.IsNotNull(createdUserResult);
            Assert.AreEqual(createdUserResult.Value.GetType(), typeof(UsersModel));

            UsersModel UserValue = (UsersModel)createdUserResult.Value;
            Assert.IsNotNull(UserValue);

            Assert.AreEqual(currentMaxId, UserValue.UserId);
            Assert.AreEqual(user.FirstName, UserValue.FirstName);
            Assert.AreEqual(user.LastName, UserValue.LastName);
            Assert.AreEqual(user.Email, UserValue.Email);
            Assert.AreEqual(user.isActive, UserValue.isActive);
            Assert.AreEqual(user.PurchaseAbility, user.PurchaseAbility);
        }

        [Test]
        public void CreateUser_InvalidUser_ShouldObject()
        {
          

            Assert.IsNotNull(_userRepo);
            Assert.IsNotNull(_userController);
            UsersModel user = null;
            Assert.IsNull(user);


            ActionResult<UsersModel> result = _userController.CreateUser(user);
            Assert.IsNotNull(result);

            ActionResult usersResult = result.Result;
            Assert.AreEqual(usersResult.GetType(), typeof(BadRequestResult));

          

        }

        [Test]
        public void EditUser_valid_ShouldObject()
        {
            Assert.IsNotNull(_userRepo);
            Assert.IsNotNull(_userController);
            UsersModel Updateduser = new UsersModel() { UserId = 2, FirstName = "Stella", LastName = "jones", Email = "Stella_jones@gmail.com", isActive = true, PurchaseAbility = true };
            Assert.IsNotNull(Updateduser);


            ActionResult<UsersModel> result = _userController.EditUser(Updateduser);
            Assert.IsNotNull(result);

            ActionResult usersResult = result.Result;
            Assert.AreEqual(usersResult.GetType(), typeof(CreatedAtActionResult));

            CreatedAtActionResult UpdaredUserResult = (CreatedAtActionResult)usersResult;
            Assert.IsNotNull(UpdaredUserResult);
            Assert.AreEqual(UpdaredUserResult.Value.GetType(), typeof(UsersModel));

            UsersModel UserValue = (UsersModel)UpdaredUserResult.Value;
            Assert.IsNotNull(UserValue);

            Assert.AreEqual(Updateduser.UserId, UserValue.UserId);
            Assert.AreEqual(Updateduser.FirstName, UserValue.FirstName);
            Assert.AreEqual(Updateduser.LastName, UserValue.LastName);
            Assert.AreEqual(Updateduser.Email, UserValue.Email);
            Assert.AreEqual(Updateduser.isActive, UserValue.isActive);
            Assert.AreEqual(Updateduser.PurchaseAbility, UserValue.PurchaseAbility);
        }

        [Test]
        public void EditUser_invalid_ShouldObject()
        {
            Assert.IsNotNull(_userRepo);
            Assert.IsNotNull(_userController);
            UsersModel Updateduser = null;
            Assert.IsNull(Updateduser);


            ActionResult<UsersModel> result = _userController.EditUser(Updateduser);
            Assert.IsNotNull(result);

            ActionResult usersResult = result.Result;
            Assert.AreEqual(usersResult.GetType(), typeof(BadRequestResult));

        }
        [Test]
        public void GetUser_valid_shouldObject()
        {
            Assert.IsNotNull(_userRepo);
            Assert.IsNotNull(_userController);
            UsersModel user = new UsersModel() { UserId = 2, FirstName = "Shaun", LastName = "andrew", Email = "shaun_andrew@hotmail.com", isActive = false, PurchaseAbility = false };
            Assert.IsNotNull(user);

            ActionResult<UsersModel> result = _userController.GetUser(user.UserId);
            Assert.IsNotNull(result);

            ActionResult usersResult = result.Result;
            Assert.AreEqual(usersResult.GetType(), typeof(CreatedAtActionResult));

            CreatedAtActionResult UpdaredUserResult = (CreatedAtActionResult)usersResult;
            Assert.IsNotNull(UpdaredUserResult);
            Assert.AreEqual(UpdaredUserResult.Value.GetType(), typeof(UsersModel));

            UsersModel UserValue = (UsersModel)UpdaredUserResult.Value;
            Assert.IsNotNull(UserValue);

            Assert.AreEqual(user.UserId, UserValue.UserId);
            Assert.AreEqual(user.FirstName, UserValue.FirstName);
            Assert.AreEqual(user.LastName, UserValue.LastName);
            Assert.AreEqual(user.Email, UserValue.Email);
            Assert.AreEqual(user.isActive, UserValue.isActive);
            Assert.AreEqual(user.PurchaseAbility, UserValue.PurchaseAbility);
        }

        [Test]
        public void GetUser_invalid_shouldObject()
        {

            Assert.IsNotNull(_userRepo);
            Assert.IsNotNull(_userController);
            UsersModel user = null;
            Assert.IsNull(user);

            ActionResult<UsersModel> result = _userController.GetUser(null);
            Assert.IsNotNull(result);

            ActionResult usersResult = result.Result;
            Assert.AreEqual(usersResult.GetType(), typeof(BadRequestResult));

            
        }
    

        [Test]
        public void getIsActive_valid_shouldObject()
        {
            Assert.IsNotNull(_userRepo);
            Assert.IsNotNull(_userController);
            UsersModel user = new UsersModel() { UserId = 2, FirstName = "Shaun", LastName = "andrew", Email = "shaun_andrew@hotmail.com", isActive = false, PurchaseAbility = false };
            Assert.IsNotNull(user);

            ActionResult<UsersModel> result = _userController.GetUser(user.UserId);
            Assert.IsNotNull(result);

            ActionResult usersResult = result.Result;
            Assert.AreEqual(usersResult.GetType(), typeof(CreatedAtActionResult));

            CreatedAtActionResult UpdaredUserResult = (CreatedAtActionResult)usersResult;
            Assert.IsNotNull(UpdaredUserResult);
            Assert.AreEqual(UpdaredUserResult.Value.GetType(), typeof(UsersModel));

            UsersModel UserValue = (UsersModel)UpdaredUserResult.Value;
            Assert.IsNotNull(UserValue);

            Assert.AreEqual(user.isActive, UserValue.isActive);
            
        }
        [Test]
        public void getIsActive_invalid_shouldObject()
        {
            
            Assert.IsNotNull(_userRepo);
            Assert.IsNotNull(_userController);
            UsersModel user = null;
            Assert.IsNull(user);

            ActionResult<UsersModel> result = _userController.GetUser(null);
            Assert.IsNotNull(result);

            ActionResult usersResult = result.Result;
            Assert.AreEqual(usersResult.GetType(), typeof(BadRequestResult));

  
        }
        [Test]
        public void SetActivity_valid_shouldObject()
        {
            Assert.IsNotNull(_userRepo);
            Assert.IsNotNull(_userController);
            UsersModel user = new UsersModel() { UserId = 2, FirstName = "Shaun", LastName = "andrew", Email = "shaun_andrew@hotmail.com", isActive = false, PurchaseAbility = false };
            Assert.IsNotNull(user);

            ActionResult<UsersModel> result = _userController.GetUser(user.UserId);
            Assert.IsNotNull(result);

            ActionResult usersResult = result.Result;
            Assert.AreEqual(usersResult.GetType(), typeof(CreatedAtActionResult));

            CreatedAtActionResult UpdaredUserResult = (CreatedAtActionResult)usersResult;
            Assert.IsNotNull(UpdaredUserResult);
            Assert.AreEqual(UpdaredUserResult.Value.GetType(), typeof(UsersModel));

            UsersModel UserValue = (UsersModel)UpdaredUserResult.Value;
            Assert.IsNotNull(UserValue);

            Assert.AreEqual(user.isActive, UserValue.isActive);
        }
        [Test]
        public void SetActivity_invalid_shouldObject()
        {
            Assert.IsNotNull(_userRepo);
            Assert.IsNotNull(_userController);
            UsersModel user = null;
            Assert.IsNull(user);

            ActionResult<UsersModel> result = _userController.GetUser(null);
            Assert.IsNotNull(result);

            ActionResult usersResult = result.Result;
            Assert.AreEqual(usersResult.GetType(), typeof(BadRequestResult));


        }
    }
}