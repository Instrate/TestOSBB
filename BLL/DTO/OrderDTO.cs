using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.BLL.DTO
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public double Price { get; set; }
        public string ListOfChanges { get; set; }

    }
}
