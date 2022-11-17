﻿
using System.Collections.Generic;

namespace Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Segment { get; set; }

        public Area Areas { get; set; }

        public List<Sales> Sales { get; set; }
    }
}