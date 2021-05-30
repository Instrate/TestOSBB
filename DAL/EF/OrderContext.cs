using Catalog.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.DAL.EF
{
    public class OrderContext
        : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

        public OrderContext(DbContextOptions options)
            : base(options)
        {
        }

    }
}
