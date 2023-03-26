using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Context
{
    internal class AppDbContext : IdentityUserContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //needed for identity
            base.OnModelCreating(modelBuilder);

        }
    }
}
