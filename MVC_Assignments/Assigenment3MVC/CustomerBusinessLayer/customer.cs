using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerBusinessLayer
{
    [Table("Customer")]
    public class customer
    {
        [Required]
        public int CustomerID { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string City { get; set; }
        [Range(1, 120)]
        public int Age { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public int Pincode { get; set; }
    }
}
