namespace CustomerApi.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class CreateCustomerModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Age { get; set; }
    }
}
