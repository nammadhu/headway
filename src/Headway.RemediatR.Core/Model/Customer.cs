﻿using Headway.RemediatR.Core.Enums;
using System.Collections.Generic;

namespace Headway.RemediatR.Core.Model
{
    public class Customer
    {
        public Customer()
        {
            Products = new List<Product>();
        }

        public int CustomerId { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string? Address4 { get; set; }
        public string? Address5 { get; set; }
        public string? Country { get; set; }
        public string? PostCode { get; set; }
        public int? SortCode { get; set; }
        public int? AccountNumber { get; set; }
        public AccountStatus AccountStatus { get; set; }
        public List<Product>? Products { get; set; }
    }
}