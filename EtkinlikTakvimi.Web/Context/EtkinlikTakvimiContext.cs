using EtkinlikTakvimi.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace EtkinlikTakvimi.Web.Context
{
    public class EtkinlikTakvimiContext:DbContext
    {
        public EtkinlikTakvimiContext(DbContextOptions<EtkinlikTakvimiContext> dbContextOptions):base(dbContextOptions)
        {

        }
        public DbSet<Event> Events { get; set; }

       

    }
}
