using Cloud_System_dev_ops.Controllers;
using Cloud_System_dev_ops.Models;
using Cloud_System_dev_ops.Repo;
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
            };// test data 

            _userRepo = new FakeUserRepo();
            _userController = new UserController(_userRepo);
        }

        [Test]
        public void CreateUser_validUser_ShouldObject()
        {
            
             
            Assert.IsNotNull(_userRepo);// not null user repo
            Assert.IsNotNull(_userController);// controller is null
            UsersModel user = new UsersModel() { UserId = 4, FirstName = "Stella", LastName = "jones", Email = "Stella_jones@gmail.com", isActive = true, PurchaseAbility = true };// new user  
            Assert.IsNotNull(user);// not null new user

            int currentMaxId = _userController.GetAllUsers().Max(x => x.UserId);// gets all users
            Assert.GreaterOrEqual(currentMaxId, 1);// get new id


            ActionResult<UsersModel> result = _userController.CreateUser(user);// calls creat user
            Assert.IsNotNull(result);// checks reults not null

            ActionResult usersResult = result.Result;// sets users result to result of result
            Assert.AreEqual(usersResult.GetType(), typeof(CreatedAtActionResult));// checks result is ofd type create at action 

            CreatedAtActionResult createdUserResult = (CreatedAtActionResult)usersResult; // creates a create at aciont
            Assert.IsNotNull(createdUserResult);// checks ts not null
            Assert.AreEqual(createdUserResult.Value.GetType(), typeof(UsersModel));// checks of type user model 

            UsersModel UserValue = (UsersModel)createdUserResult.Value;// gets the value of the create at action 
            Assert.IsNotNull(UserValue);// checks not null 

            Assert.AreEqual(currentMaxId + 1, UserValue.UserId);//checks if it matches 
            Assert.AreEqual(user.FirstName, UserValue.FirstName);//checks if it matches
            Assert.AreEqual(user.LastName, UserValue.LastName);//checks if it matches
            Assert.AreEqual(user.Email, UserValue.Email);//checks if it matches
            Assert.AreEqual(user.isActive, UserValue.isActive);//checks if it matches
            Assert.AreEqual(user.PurchaseAbility, user.PurchaseAbility);//checks if it matches
        }

        [Test]
        public void CreateUser_InvalidUser_ShouldObject()
        {
            Assert.IsNotNull(_userRepo);// check repos not null     
            Assert.IsNotNull(_userController);// checks controlle is not null 
            UsersModel user = null;// sets user as ull 
            Assert.IsNull(user);// ensure user is null 

            ActionResult<UsersModel> result = _userController.CreateUser(user); // sends null user to controller 
            Assert.IsNotNull(result);// checks return is not null 

            ActionResult usersResult = result.Result;// usersresult is result of result
            Assert.AreEqual(usersResult.GetType(), typeof(BadRequestResult));// ensures its a bad request
        }

        [Test]
        public void EditUser_valid_ShouldObject()
        {
            Assert.IsNotNull(_userRepo);// check repos not null 
            Assert.IsNotNull(_userController);// checks controlle is not null 
            UsersModel Updateduser = new UsersModel()  {UserId = 2, FirstName = "Shaun", LastName = "andrew", Email = "shaun_andrew@hotmail.com", isActive = false, PurchaseAbility = false };// user to update
            Assert.IsNotNull(Updateduser);//chekcs not null 

            Updateduser.LastName = "hand";// change lastname

            ActionResult<UsersModel> result = _userController.EditUser(Updateduser); //calls edit user and set to result 
            Assert.IsNotNull(result);// checks not null

            UsersModel updatedUser = result.Value;// sets updatedUser to result.Value
            Assert.IsNotNull(updatedUser);   // checks updatedUser not null 
            Assert.AreEqual(Updateduser.LastName, updatedUser.LastName);// checks the name has changed 
     
        }

        [Test]
        public void EditUser_invalid_ShouldObject()
        {
            Assert.IsNotNull(_userRepo);// check repos not null
            Assert.IsNotNull(_userController);// checks controlle is not null 
            UsersModel Updateduser = null;// Updateduser is null
            Assert.IsNull(Updateduser);// check Updateduser is null


            ActionResult<UsersModel> result = _userController.EditUser(Updateduser);// sets result to the edit user action
            Assert.IsNotNull(result);// checks its not null

            ActionResult usersResult = result.Result;// sets usersResult to the result.Result
            Assert.AreEqual(usersResult.GetType(), typeof(BadRequestResult));// checks  usersResult is of type bad request 
        }

        [Test]
        public void GetUser_valid_shouldObject()
        {
            Assert.IsNotNull(_userRepo);// check repos not null
            Assert.IsNotNull(_userController);// checks controlle is not null 
            UsersModel user = new UsersModel() { UserId = 2, FirstName = "Shaun", LastName = "andrew", Email = "shaun_andrew@hotmail.com", isActive = false, PurchaseAbility = false };// users is a valid user 
            Assert.IsNotNull(user);// user is not null

            ActionResult<UsersModel> result = _userController.GetUser(user.UserId).Value;// result is the value of the get user controller function 
            Assert.IsNotNull(result);// result is not null
            Assert.IsNotNull(result.Value);// result value is not null

            UsersModel usersResult = result.Value;//  usersResult resut.value 
            Assert.IsNotNull(usersResult);// checks not null

            Assert.AreEqual(user.UserId, usersResult.UserId);//checks if it matches
            Assert.AreEqual(user.FirstName, usersResult.FirstName);//checks if it matches
            Assert.AreEqual(user.LastName, usersResult.LastName);//checks if it matches
            Assert.AreEqual(user.Email, usersResult.Email);//checks if it matches
            Assert.AreEqual(user.isActive, usersResult.isActive);//checks if it matches
            Assert.AreEqual(user.PurchaseAbility, usersResult.PurchaseAbility);//checks if it matches
        }

        [Test]
        public void GetUser_invalid_shouldObject()
        {

            Assert.IsNotNull(_userRepo);// check repos not null
            Assert.IsNotNull(_userController);// checks controlle is not null 
            UsersModel user = null;// user is null
            Assert.IsNull(user);// checks user is null

            ActionResult<UsersModel> result = _userController.GetUser(null);// sets result to getuser function
            Assert.IsNotNull(result);// checks not null

            ActionResult usersResult = result.Result;// sets UserResult to the result of result
            Assert.AreEqual(usersResult.GetType(), typeof(BadRequestResult));// checks the resut is of type badrequest
        }
    

        [Test]
        public void getIsActive_valid_shouldObject()
        {
            Assert.IsNotNull(_userRepo);// check repos not null
            Assert.IsNotNull(_userController);// checks controlle is not null 
            UsersModel user = new UsersModel() { UserId = 2, FirstName = "Shaun", LastName = "andrew", Email = "shaun_andrew@hotmail.com", isActive = false, PurchaseAbility = false };// sets User to valid user
            Assert.IsNotNull(user);// check user isnt null

            ActionResult<UsersModel> result = _userController.GetUser(user.UserId).Value;// sets result to the value of get user function
            Assert.IsNotNull(result);// checks result isnt null 
            Assert.IsNotNull(result.Value);// checks value of resutl isnt null

            UsersModel usersResult = result.Value;// sets userResult to result.value
            Assert.IsNotNull(usersResult);// checks user isnt null
            Assert.AreEqual(user.isActive, usersResult.isActive);// checks is active match 

        }

        [Test]
        public void getIsActive_invalid_shouldObject()
        {

            Assert.IsNotNull(_userRepo);// check repos not null
            Assert.IsNotNull(_userController);// checks controlle is not null 
            UsersModel user = null;// user is null
            Assert.IsNull(user);// cheks is null

            ActionResult<UsersModel> result = _userController.GetUser(null);// result is the return if getuser with a null users
            Assert.IsNotNull(result);// checks result isnt null

            ActionResult usersResult = result.Result; // user result is result. result
            Assert.AreEqual(usersResult.GetType(), typeof(BadRequestResult));// checks userresult id of ttpye bad request

  
        }
        [Test]
        public void SetActivity_valid_shouldObject()
        {
            Assert.IsNotNull(_userRepo);// check repos not null
            Assert.IsNotNull(_userController);// checks controlle is not null 
            UsersModel user = new UsersModel() { UserId = 2, FirstName = "Shaun", LastName = "andrew", Email = "shaun_andrew@hotmail.com", isActive = false, PurchaseAbility = false };// valid user
            Assert.IsNotNull(user);// checks user is not null

            ActionResult<UsersModel> result = _userController.ToggleActivity(user);// result is set to the return value of toggleactivity function 
            Assert.IsNotNull(result);// result is not null
            Assert.IsNotNull(result.Value);// result. value is not null

            UsersModel usersResult = result.Value;// userresult is result.value
            Assert.IsNotNull(usersResult);// check usersresult is not null

            Assert.AreEqual(user.isActive, usersResult.isActive);// checks are equal
        }
        [Test]
        public void SetActivity_invalid_shouldObject()
        {
            Assert.IsNotNull(_userRepo);// check repos not null
            Assert.IsNotNull(_userController);// checks controlle is not null 
            UsersModel user = null;// user is null
            Assert.IsNull(user);// checks user is null

            ActionResult<UsersModel> result = _userController.GetUser(null);// result is the return of the get usert controller function 
            Assert.IsNotNull(result);// result is not null

            ActionResult usersResult = result.Result;// usersResult is result.Result
            Assert.AreEqual(usersResult.GetType(), typeof(BadRequestResult));// usersResult is if type badrequest
        }
    }
}