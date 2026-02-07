using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PetBoardingApp.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
      : base("DefaultConnection", throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
        }

        public DbSet<EmployeeModel> EmployeeModels { get; set; }
        public DbSet<BookingModel> BookingModels { get; set; }
        public DbSet<OwnerModel> OwnerModels { get; set; }
        public DbSet<ContactUsSubmission> ContactUsSubmissions { get; set; }
        public DbSet<PetModel> PetModels { get; set; }
        public DbSet<BillingModel> BillingModels { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}