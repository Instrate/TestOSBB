using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Catalog.DAL.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public double Price { get; set; }
        public string ListOfChanges { get; set; }

        public List<User> Users { get; set; }
    }
}
