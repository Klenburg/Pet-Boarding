using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetBoardingApp.Models;

namespace PetBoardingApp.Controllers
{
    public class BookingsController : Controller
    {
        // GET: Bookings
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(Guid? petID, string startTime, string endTime, Boolean cancelBooking, double cost)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            DateTime parsedStartTime = DateTime.Parse(startTime);
            DateTime parsedEndTime = DateTime.Parse(endTime);

            if (parsedStartTime >= parsedEndTime)
            {
                return Content("Start time must be earlier than end time.");
            }

            BookingModel bookingModel = new BookingModel();

            dbContext.BookingModels.Add(bookingModel);
            bookingModel.StartTime = parsedStartTime;
            bookingModel.EndTime = parsedEndTime;
            bookingModel.CancelBooking = cancelBooking;
            bookingModel.Cost = cost;

            PetModel petModel = dbContext.PetModels.FirstOrDefault(x => x.PetID == petID);
            if (petModel == null)
            {
                return Content("Error: Booking must be associated with a valid pet.");
            }

            bookingModel.PetID = petID;

            if (petModel.Bookings == null)
            {
                petModel.Bookings = new List<BookingModel>();
            }

            petModel.Bookings.Add(bookingModel);

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

            return Content("Created: " + bookingModel.BookingID);
        }

        public ActionResult Read(Guid Id)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            BookingModel bookingModel = dbContext.BookingModels.FirstOrDefault(x => x.BookingID == Id);

            if (bookingModel == null)
            {
                return Content("No Contact found for that ID");
            }

            return Content("Booking - ID: " + bookingModel.BookingID + " Start Time: " + bookingModel.StartTime + " End Time: " +
                bookingModel.EndTime + " Cancel Booking: " + bookingModel.CancelBooking + " Booking Cost: " + bookingModel.Cost + 
                " For PetID: " + bookingModel.PetID);
        }

        public ActionResult Delete(Guid Id)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            BookingModel bookingModel = dbContext.BookingModels.FirstOrDefault(x => x.BookingID == Id);

            if (bookingModel != null)
            {
                dbContext.BookingModels.Remove(bookingModel);
            }

            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content("Error: " + ex.Message);
            }

            return Content("Delete");
        }
    }
}