using EventsApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApplication.Data
{
    //make sure it inherits from the dbcontext class
    //reserve namespace by installing MEC
    public class ApplicationDbContext: DbContext
    {
        //this is called contructor chaining: where we create a constructor inside the child class, and passing the entity over to the parent/base class
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<DecorDetail> DecorDetails { get; set; }

    }
}
