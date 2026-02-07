using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetBoardingApp.Models
{
    public class PetModel
    {
        [Key]

        public Guid PetID { get; set; }

        [Required]
        [MaxLength(100)]
        public string PetName { get; set; }

        [MaxLength(100)]
        public string Breed { get; set; }

        public int PetAge { get; set; }

        [Required]
        [MaxLength(1000)]
        public string FeedInstruct { get; set; }

        [MaxLength(1000)]
        public string SpecialInstruct { get; set; }

        [Required]
        public string EmergencyContact { get; set; }

        public Guid? EmployeeID { get; set; }

        [ForeignKey("EmployeeID")]
        public EmployeeModel Employee { get; set; }

        public List<OwnerModel> Owner { get; set; }
        public virtual List<BookingModel> Bookings { get; set; }
        public PetModel()
        {
            PetID = Guid.NewGuid();

        }

    }
}