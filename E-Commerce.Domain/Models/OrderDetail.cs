﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Models
{
    public class OrderDetail
    {
        public int Id  { get; set; }  

        public int  OrderID { get; set; }  

        public int  ProductID { get; set; } 

        public int Quantity { get; set; }

       
    }
}
