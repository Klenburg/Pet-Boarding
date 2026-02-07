using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetBoardingApp.Models
{
    public class BillingModel
    {
        [Key]
        public Guid BillingID { get; set; }

        [Required]
        public double Tax {  get; set; }

        [Required]
        public double EmployeeComp {  get; set; }

        [Required]
        public Guid BookingID { get; set; }
        [ForeignKey("BookingID")] 
        public BookingModel Booking { get; set; }

        public Guid EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        public EmployeeModel Employee { get; set; }

        public BillingModel()
        {
            BillingID = Guid.NewGuid();
        }
    }
}