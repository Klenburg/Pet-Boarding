using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetBoardingApp.Models;

namespace PetBoardingApp.Controllers
{
    public class PetsController : Controller
    {
        // GET: Pets
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(string petName, string breed, int petAge, 
            string feedInstruct, string specialInstruct, string emergencyContact, Guid? employeeID)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            PetModel petModel = new PetModel();

            dbContext.PetModels.Add(petModel);
            petModel.PetName = petName;
            petModel.Breed = breed;
            petModel.PetAge = petAge;
            petModel.FeedInstruct = feedInstruct;
            petModel.SpecialInstruct = specialInstruct;
            petModel.EmergencyContact = emergencyContact;

            if (employeeID.HasValue)
            {
                petModel.EmployeeID = employeeID.Value;
            }

            try
            {
                dbContext.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                var errorMessages = new List<string>();

                foreach (var entityErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityErrors.ValidationErrors)
                    {
                        errorMessages.Add($"Property: {validationError.PropertyName}, Error: {validationError.ErrorMessage}");
                    }
                }

                return Content("Validation failed: " + string.Join("; ", errorMessages));
            }

            return Content("Created: " + petModel.PetID);
        }

        public ActionResult Read(Guid Id)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            PetModel petModel = dbContext.PetModels.FirstOrDefault(x => x.PetID == Id);


            if (petModel == null)
            {
                return Content("No Contact found for that ID");
            }

            return Content("Pet - ID: " + petModel.PetID + " Pet Name: " + petModel.PetName + " Breed: " +
                petModel.Breed + " Pet Age: " + petModel.PetAge + " Feeding Instructions: " + petModel.FeedInstruct + 
                " Special Care Instructions: " + petModel.SpecialInstruct + " Emergency Contact Number: " + 
                petModel.EmergencyContact);
        }

        public ActionResult Delete(Guid Id)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            try
            {
                PetModel petModel = dbContext.PetModels.FirstOrDefault(x => x.PetID == Id);

                if (petModel != null)
                {
                    foreach (var booking in petModel.Bookings.ToList())
                    {
                        dbContext.BookingModels.Remove(booking);
                    }

                    dbContext.PetModels.Remove(petModel);
                    dbContext.SaveChanges();

                    return Content("Deleted successfully.");
                }

                return Content("Pet not found.");
            }
            catch (Exception ex)
            {
                return Content("Error: " + (ex.InnerException?.Message ?? ex.Message));
            }
        }
    }
}