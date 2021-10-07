using COAChallenge.Controllers;
using COAChallenge.DataAccess.ModelsEF;
using COAChallenge.UnitOfWork;
using COAChallenge.ViewModels;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace COATesting
{    
    public class UserControllerTest
    {
        [Fact]
        public void GetUsers_ShouldReturnUsersCorrectly()
        {
            var expectedUserResult = 3;
            var expected = A.CollectionOfDummy<User>(expectedUserResult);
            var coaChallenger = A.Fake<IUofW>();
            A.CallTo(() => coaChallenger.UserRepository.GetAll()).Returns(expected);
            var controller = new HomeController(coaChallenger);

            var actionResult = controller.GetUsers();

            var result = actionResult.Result as OkObjectResult;
            var actual = result.Value as IEnumerable<User>;
            Assert.Equal<User>(expected, actual);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]        
        public void GetUserById_ItShouldReturnTheUserByMeansOfTheId(int id)
        {
            var coaChallenger = A.Fake<IUofW>();
            var controller = new HomeController(coaChallenger);
            var expectedUserResult = 3;
            var expected = A.CollectionOfDummy<User>(expectedUserResult);
            A.CallTo(() => coaChallenger.UserRepository.GetById(id)).Returns(expected[id]);

            var actionResult = controller.GetUserById(id);

            var result = actionResult.Result as OkObjectResult;
            var actual = result.Value;
            Assert.Equal(expected[id], actual);
        }
                
        [Fact]
        public void CreatUser_ItShouldNotGiveNullIfTheUserCouldBeAdded() 
        {
            var coaChallenger = A.Fake<IUofW>();
            var controller = new HomeController(coaChallenger);
            var user = A.Fake<User>();
            var userVm = A.Fake<UserViewModel>();
            A.CallTo(() => coaChallenger.UserRepository.Insert(user));

            var actionResult = controller.CreatUser(userVm);

            var result = actionResult as OkObjectResult;
            var actual = result.Value;
            Assert.NotNull(actual);
        }

        [Fact]
        public void EditUser_ItShouldNotGiveNullSinceItSendsTheUserWithTheNewData()
        {
            var coaChallenger = A.Fake<IUofW>();
            var controller = new HomeController(coaChallenger);            
            var userVm = A.Fake<UserViewModel>();
            var expectedUserResult = 3;
            var expected = A.CollectionOfDummy<User>(expectedUserResult);
            A.CallTo(() => coaChallenger.UserRepository.Update(expected[1]));

            var actionResult = controller.EditUser(userVm, expected[1].Id);

            var result = actionResult.Result as OkObjectResult;
            var actual = result.Value;
            Assert.NotNull(actual);
        }
    }
}
