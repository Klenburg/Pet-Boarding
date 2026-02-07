using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetBoardingApp.Models;
using PetBoardingApp.ViewModels;

namespace PetBoardingApp.Controllers
{
    public class ContactUsController : Controller
    {
        // GET: ContactUsSubmission
        public ActionResult Index()
        {
            ContactUsSubmissionVM contactUsSubmissionVM = new ContactUsSubmissionVM();
            return View(contactUsSubmissionVM);
        }

        [HttpPost]
        public ActionResult Index(ContactUsSubmissionVM contactUsSubmissionVM)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    var submission = new ContactUsSubmission
                    {
                        Name = contactUsSubmissionVM.Name,
                        Email = contactUsSubmissionVM.Email,
                        Message = contactUsSubmissionVM.Message
                    };

                    db.ContactUsSubmissions.Add(submission);
                    db.SaveChanges();
                }
                return RedirectToAction("ContactUsSuccessful");
            }
            else
            {
                return View(contactUsSubmissionVM);
            }
        }
        public ActionResult ContactUsSuccessful()
        {
            return View();
        }
    }
}