namespace OrderApi.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class OrderModel
    {
        [Required]
        public Guid CustomerGuid { get; set; }
        
        [Required]
        public string CustomerFullName { get; set; }
    }
}
