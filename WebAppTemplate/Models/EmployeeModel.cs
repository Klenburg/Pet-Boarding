using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace PetBoardingApp.Models
{
    public class EmployeeModel
    {
        [Key]
        public Guid EmployeeID { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        public decimal HourlyWage { get; set; }
        public DateTime ClockInTime { get; set; }
        public DateTime ClockOutTime { get; set; }

        public List<PetModel> Pets { get; set; }
        public List<BillingModel> Billings { get; set; }

        public DateTime DateTimeCreated { get; set; }

        public EmployeeModel()
        {
            EmployeeID = Guid.NewGuid();
            DateTimeCreated = DateTime.UtcNow;
        }

    }
}