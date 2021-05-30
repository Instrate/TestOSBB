using System;
using System.Collections.Generic;
using System.Text;

namespace OSBB.Security.Identity
{
    public class Admin
        : User
    {
        public Admin(int userId, string name, int osbbId) 
            : base(userId, name, osbbId, nameof(Admin))
        {
        }
    }
}
