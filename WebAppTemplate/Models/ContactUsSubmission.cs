using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetBoardingApp.Models
{
    public class ContactUsSubmission
    {
        public Guid ContactUsSubmissionID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }

        public ContactUsSubmission()
        {
            ContactUsSubmissionID = Guid.NewGuid();
        }
    }
}