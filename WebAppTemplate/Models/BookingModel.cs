using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace PetBoardingApp.Models
{
    public class BookingModel
    {
        [Key]
        public Guid BookingID { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public Boolean CancelBooking { get; set; }

        [Required]
        public double Cost { get; set; }

        public Guid? PetID { get; set; }
        [ForeignKey("PetID")]
        public virtual PetModel Pet { get; set; }

        public Guid? OwnerID { get; set; }
        [ForeignKey("OwnerID")]
        public OwnerModel Owner { get; set; }

        public DateTime DateTimeCreated { get; set; }

        public BookingModel()
        {
            BookingID = Guid.NewGuid();
            DateTimeCreated = DateTime.UtcNow;
        }
    }
}