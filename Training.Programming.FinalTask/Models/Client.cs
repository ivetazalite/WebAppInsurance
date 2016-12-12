using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training.Programming.FinalTask.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string SocialSecurityNumber { get; set; }
        public Sex Sex { get; set; }
        public Employee ClientType { get; set; }
        public virtual List<Policy> Policies { get; set; }
    }

    public enum Sex
    {
        Male,
        Female,
        Other
    }

    public enum Employee
    {
        Yes,
        No
    }
}