﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMasterDataEntry.Models
{
    public class OrderVM
    {
        public string OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Description { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}