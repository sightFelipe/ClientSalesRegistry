using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientSalesRegistry.Models
{
    public class Sale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }

        [Required]
        public DateTime SaleDate { get; set; }

        [ForeignKey("Customer")] 
        public int CustomerId { get; set; } 

        public Customer Customer { get; set; } 

        public List<SaleItem> SaleItems { get; set; } = new List<SaleItem>(); 
    }
}