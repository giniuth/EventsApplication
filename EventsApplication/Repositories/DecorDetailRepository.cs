using EventsApplication.Data;
using EventsApplication.Interfaces;
using EventsApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApplication.Repositories
{
    public class DecorDetailRepository : Repository<DecorDetail>, IDecorDetailRepository
    {
        public DecorDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}


