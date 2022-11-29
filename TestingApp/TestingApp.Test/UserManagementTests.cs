
using System.Reflection;
using TestingApp.functionallity;
using Xunit;

namespace TestingApp.Test
{
    public class UserManagementTests
    {
        [Fact]
        public void Add_CreateUser(){
            //Arrange
            var userManagement= new UserManagement();
            //Acc
            userManagement.Add(new("mario", "pratama"));
            //Assert
            var savedUser= Assert.Single(userManagement.AllUsers);
            Assert.NotNull(savedUser);
            Assert.Equal("mario", savedUser.firstName);
            Assert.Equal("pratama", savedUser.lastName);
            Assert.False(savedUser.VerfiedEmail);
        }

        [Fact]
        public void Update_UpdateUserMobileNumber(){
            //Arrange
            var userManagement = new UserManagement();

            //Act
            userManagement.Add(new("mario", "pratama"));
            var firstUser= userManagement.AllUsers.First();
            firstUser.Phone= "+6282378794325";

            userManagement.UpdatePhone(firstUser);

            //Assert
            var savedUser= Assert.Single(userManagement.AllUsers);
            Assert.NotNull(savedUser);
            Assert.Equal("+6282378794325", savedUser.Phone);
        }
    }
}