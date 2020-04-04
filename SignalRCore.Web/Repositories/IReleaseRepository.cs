using System.Collections.Generic;
using SignalRCore.Web.Models;

namespace SignalRCore.Web.Repositories
{
    public interface IReleaseRepository
    {
        IEnumerable<ReleaseModel> GetMessages();
    }
}