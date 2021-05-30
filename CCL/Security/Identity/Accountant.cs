using System;
using System.Collections.Generic;
using System.Text;

namespace OSBB.Security.Identity
{
    public class Accountant
        : User
    {
        public Accountant(int userId, string name, int osbbId) 
            : base(userId, name, osbbId, nameof(Accountant))
        {
        }
    }
}
