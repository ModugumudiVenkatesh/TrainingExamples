using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CoreRazorExample.Models;
using MVCExample.Models;

namespace CoreRazorExample.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Patient> patients { get; set; }

        public DbSet<Doctor> doctor { get; set; }
    }
}
