using Catalog.BLL.Services.Impl;
using Catalog.BLL.Services.Interfaces;
using Catalog.DAL.EF;
using Catalog.DAL.Entities;
using Catalog.DAL.Repositories.Interfaces;
using Catalog.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Moq;
using OSBB.Security;
using OSBB.Security.Identity;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace BLL.Tests
{
    public class UserServiceTests
    {

        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new UserService(nullUnitOfWork));
        }

        [Fact]
        public void GetStreets_UserIsAdmin_ThrowMethodAccessException()
        {
            // Arrange
            User user = new Admin(1, "test", 1);
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IUserService userService = new UserService(mockUnitOfWork.Object);

            // Act
            // Assert
            Assert.Throws<MethodAccessException>(() => userService.GetUsers(0));
        }

        [Fact]
        public void GetUsers_StreetFromDAL_CorrectMappingToStreetDTO()
        {
            // Arrange
            User user = new Director(1, "test", 1);
            SecurityContext.SetUser(user);
            var userService = GetUserService();

            // Act
            var actualUserDto = userService.GetUsers(0).First();

            // Assert
            Assert.True(
                actualUserDto.OrderID == 1
                && actualUserDto.FullName == "testN"
                );
        }

        IUserService GetUserService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedUser = new User() { OrderID = 1, FullName = "testN", OSBBID = 2};
            var mockDbSet = new Mock<IUserRepository>();
            mockDbSet.Setup(z => 
                z.Find(
                    It.IsAny<Func<Street,bool>>(), 
                    It.IsAny<int>(), 
                    It.IsAny<int>()))
                  .Returns(
                    new List<User>() { expectedUser }
                    );
            mockContext
                .Setup(context =>
                    context.Streets)
                .Returns(mockDbSet.Object);

            IUserService userService = new UserService(mockContext.Object);

            return userService;
        }
    }
}
