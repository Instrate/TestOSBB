using System;
using System.Collections.Generic;
using System.Text;
using Catalog.DAL.Entities;
using Catalog.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Catalog.DAL.EF;
using System.Linq;

namespace Catalog.DAL.Repositories.Impl
{
    public class UserRepository
        : BaseRepository<User>, IUserRepository
    {
        internal UserRepository(OrderContext context) 
            : base(context)
        {
        }
    }
}
