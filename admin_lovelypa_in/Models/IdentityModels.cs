using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace admin_lovelypa_in.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>()
                .ToTable("MPA_ADMIN_USERS");

            modelBuilder.Entity<ApplicationUser>().ToTable("MPA_ADMIN_USERS");

           // modelBuilder.Entity<ApplicationUserManager>().ToTable("MPA_ADMIN_USERS");

            modelBuilder.Entity<IdentityRole>()
                .ToTable("MPA_ADMIN_ROLES");

            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("MPA_ADMIN_USER_ROLES");

            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("MPA_ADMIN_USER_CLAIMS");

            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("MPA_ADMIN_USER_LOGINS");
        }
        
        
    }
}