using Nest;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApplication.model
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
      
        public string? Name { get; set; }
        [StringLength(50)]
        public string? Address { get; set; }
      
        [Range(typeof(DateTime), "1/1/1920", "31/12/2020")]
        public DateTime DateOfBirth { get; set; }
        public decimal  Balance { get; set; }
        [Range (0,100)]
        public int OrdersNumber { get; set; }
    }
}
