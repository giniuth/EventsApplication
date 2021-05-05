using EventsApplication.Data;
using EventsApplication.Interfaces;
using EventsApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApplication.Repositories
{
    public class EventTypeRepository : Repository<EventType>, IEventTypeRepository
    {
        public EventTypeRepository(ApplicationDbContext dbContext): base (dbContext)
        {

        }
    }
}
