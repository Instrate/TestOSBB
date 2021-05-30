using Catalog.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Catalog.DAL.Entities;
using Catalog.BLL.DTO;
using Catalog.DAL.Repositories.Interfaces;
using AutoMapper;
using Catalog.DAL.UnitOfWork;
using OSBB.Security;
using OSBB.Security.Identity;

namespace Catalog.BLL.Services.Impl
{
    public class UserService
        : IUserService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;

        public UserService( 
            IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(
                    nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        /// <exception cref="MethodAccessException"></exception>
        public IEnumerable<UserDTO> GetUsers(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(FullName))
            {
                throw new MethodAccessException();
            }
            var orderId = user.OSBBID;
            var usersEntities = 
                _database
                    .Users
                    .Find(z => z.OSBBID == orderId, pageNumber, pageSize);
            var mapper = 
                new MapperConfiguration(
                    cfg => cfg.CreateMap<User, UserDTO>()
                    ).CreateMapper();
            var usersDto = 
                mapper
                    .Map<IEnumerable<User>, List<UserDTO>>(
                        usersEntities);
            return usersDto;
        }

        public void AddStreet(UserDTO customer)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(FullName))
            {
                throw new MethodAccessException();
            }
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            validate(customer);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>()).CreateMapper();
            var streetEntity = mapper.Map<UserDTO, User>(customer);
            _database.Streets.Create(streetEntity);
        }

        private void validate(UserDTO customer)
        {
            if (string.IsNullOrEmpty(customer.FullName))
            {
                throw new ArgumentException("Name повинне містити значення!");
            }
        }
    }
}
