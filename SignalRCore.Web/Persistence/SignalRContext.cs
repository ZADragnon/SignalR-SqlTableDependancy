using Microsoft.EntityFrameworkCore;
using SignalRCore.Web.Models;

namespace SignalRCore.Web.Persistence
{
    public class SignalRContext : DbContext
    {
        public SignalRContext(DbContextOptions<SignalRContext> options)
            : base(options)
        {
        }

        public DbSet<ReleaseModel> Releases { get; set; }
    }
}