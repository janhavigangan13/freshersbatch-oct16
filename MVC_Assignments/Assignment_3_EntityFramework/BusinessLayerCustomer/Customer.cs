using System.ComponentModel.DataAnnotations;


namespace BusinessLayerCustomer
{
    public class Customer
    {
        [Key]
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
