using EventsApplication.Data;
using EventsApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApplication.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        ApplicationDbContext _repoContext;
        public RepositoryWrapper(ApplicationDbContext repoContext)
        {
            _repoContext = repoContext;
        }
        IEventTypeRepository _EventTypes;

        IDecorDetailRepository _DecorDetails;

        public IEventTypeRepository EventTypes
        {
            get
            {
                if(_EventTypes == null)
                {
                    _EventTypes = new EventTypeRepository(_repoContext);
                }
                return _EventTypes;
            }
        }

        public IDecorDetailRepository DecorDetails
        {
            get
            {
                if (_DecorDetails == null)
                {
                    _DecorDetails = new DecorDetailRepository(_repoContext);
                }
                return _DecorDetails;

            }
        }

        void IRepositoryWrapper.Save()
        {
               _repoContext.SaveChanges();
        }
    }
}
