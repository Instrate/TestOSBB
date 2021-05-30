using System;
using Xunit;
using Catalog.DAL.Repositories.Impl;
using Catalog.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Catalog.DAL.Entities;
using Catalog.DAL.Repositories.Interfaces;
using System.Linq;
using Moq;

namespace DAL.Tests
{
    class TestUserRepository
        : BaseRepository<User>
    {
        public TestUserRepository(DbContext context) 
            : base(context)
        {
        }
    }

    public class BaseRepositoryUnitTests
    {

        [Fact]
        public void Create_InputUserInstance_CalledAddMethodOfDBSetWithUserInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<OrderContext>()
                .Options;
            var mockContext = new Mock<OrderContext>(opt);
            var mockDbSet = new Mock<DbSet<User>>();
            mockContext
                .Setup(context => 
                    context.Set<User>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            var repository = new TestUserRepository(mockContext.Object);

            User expectedUser = new Mock<User>().Object;

            //Act
            repository.Create(expectedUser);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedUser
                    ), Times.Once());
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<OrderContext>()
                .Options;
            var mockContext = new Mock<OrderContext>(opt);
            var mockDbSet = new Mock<DbSet<User>>();
            mockContext
                .Setup(context =>
                    context.Set<User>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            //IStreetRepository repository = uow.Streets;
            var repository = new TestUserRepository(mockContext.Object);

            User expectedUser = new User() { OrderID = 1};
            mockDbSet.Setup(mock => mock.Find(expectedUser.OrderID)).Returns(expectedUser);

            //Act
            repository.Delete(expectedUser.OrderID);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedUser.OrderID
                    ), Times.Once());
            mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedUser
                    ), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<OrderContext>()
                .Options;
            var mockContext = new Mock<OrderContext>(opt);
            var mockDbSet = new Mock<DbSet<User>>();
            mockContext
                .Setup(context =>
                    context.Set<User>(
                        ))
                .Returns(mockDbSet.Object);

            User expectedUser = new User() { OrderID = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedUser.OrderID))
                    .Returns(expectedUser);
            var repository = new TestUserRepository(mockContext.Object);

            //Act
            var actualUser = repository.Get(expectedUser.OrderID);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedUser.OrderID
                    ), Times.Once());
            Assert.Equal(expectedUser, actualUser);
        }

      
    }
}
