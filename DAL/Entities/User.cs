using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.DAL.Entities
{
    public class User
    {
        public string FullName { get; set; }
        public int OrderID { get; set; }
        
        public int OSBBID { get; set; }
        public Order OSBB { get; set; }
    }
}
