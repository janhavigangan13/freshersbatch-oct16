using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Assignment2_1MVC.Models
{
    [Table("BusInfo")]
    public class BusInfo
    {
        public int BusID { get; set; }
        public string BoardingPoint { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime TravelDate { get; set; }
        [Required(ErrorMessage = "Amount cannot be empty")]
        public decimal Amount { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
    }
}