﻿namespace CustomerApi.Domain.Entities
{
    using System;
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Age { get; set; }
    }
}
