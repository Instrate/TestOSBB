using Catalog.DAL.Entities;
using Catalog.DAL.Repositories.Impl;
using Catalog.DAL.Repositories.Interfaces;
using Catalog.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;

namespace Catalog.DAL.EF
{
    public class EFUnitOfWork
        : IUnitOfWork
    {
        private OrderContext order;
        private OrderRepository orderRepository;
        private UserRepository userRepository;

        public EFUnitOfWork(OrderContext context)
        {
            order = context;
        }
        public IOrderRepository Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(order);
                return orderRepository;
            }
        }

        public IUserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(order);
                return userRepository;
            }
        }

        public void Save()
        {
            order.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    order.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
