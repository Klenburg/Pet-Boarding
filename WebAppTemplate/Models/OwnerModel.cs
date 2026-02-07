using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Web;

namespace PetBoardingApp.Models
{
    public class OwnerModel
    {
        [Key]

        public Guid OwnerID { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [MaxLength(100)]
        public string OwnerEmail { get; set; }

        public Guid PetID { get; set; }

        [ForeignKey("PetID")]
        public PetModel Pet { get; set; }
        public List<BookingModel> Bookings { get; set; }

        public OwnerModel()
        {
            OwnerID = Guid.NewGuid();
        }
    }
}