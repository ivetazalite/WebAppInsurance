using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training.Programming.FinalTask.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public decimal Premium { get; set; }

        public virtual List<Policy> Policies { get; set; }
    }
}