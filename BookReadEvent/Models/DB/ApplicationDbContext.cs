using BookReadEvent.Models.AccountModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadEvent.Models.DB
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions option):base(option)
        {

        }
        public DbSet<EventModel> Events { get; set; }
        public DbSet<Comment> comments { get; set; }

    }
}
