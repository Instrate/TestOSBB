using Catalog.DAL.Entities;
using Catalog.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.DAL.Repositories.Interfaces
{
    public interface IUserRepository
        : IRepository<User>
    {
    }
}
