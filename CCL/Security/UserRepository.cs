using Catalog.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Catalog.DAL.Repositories.Impl
{
    public class UserRepository
         : BaseRepository<User>
    {
        public UserRepository(OSBBContext context) : base(context)
        {
        }
    }
}
