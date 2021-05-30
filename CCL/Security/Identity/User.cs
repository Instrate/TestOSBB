using System;
using System.Collections.Generic;
using System.Text;

namespace OSBB.Security.Identity
{
    public abstract class User
    {
        public User(int userId, string name, int osbbId, string userType)
        {
            UserId = userId;
            Name = name;
            OSBBID = osbbId;
            UserType = userType;
        }
        public int UserId { get; }
        public string Name { get; }
        public int OSBBID { get; }
        protected string UserType { get; }
    }
}
