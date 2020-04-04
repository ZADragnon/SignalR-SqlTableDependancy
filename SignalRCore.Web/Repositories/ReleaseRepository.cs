using System.Collections.Generic;
using SignalRCore.Web.Models;
using SignalRCore.Web.Persistence;

namespace SignalRCore.Web.Repositories
{
    public class ReleaseRepository : IReleaseRepository
    {
        private readonly SignalRContext _context;

        public ReleaseRepository(SignalRContext context)
        {
            _context = context;
        }
        
        public IEnumerable<ReleaseModel> GetMessages()
        {
            return _context.Releases;
        }
    }
}