using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training.Programming.FinalTask.Models
{
    public class Policy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PolicyId { get; set; }
        public string PolicyNumber { get; set; }
        public decimal Premium { get; set; }
        public State State { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Client Client { get; set; }
        public virtual Product Product { get; set; }
    }

    public enum State
    {
        Draft,
        Active,
        Closed
    }
}
