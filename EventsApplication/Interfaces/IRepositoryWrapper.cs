using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApplication.Interfaces
{
  public  interface IRepositoryWrapper
    {
        IEventTypeRepository EventTypes { get; }
        IDecorDetailRepository DecorDetails { get; }
        void Save();
    }
}
