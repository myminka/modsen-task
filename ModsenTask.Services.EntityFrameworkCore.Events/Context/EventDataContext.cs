using Microsoft.EntityFrameworkCore;
using ModsenTask.Services.EntityFrameworkCore.Events.Entities;

namespace ModsenTask.Services.EntityFrameworkCore.Events.Context
{
    public class EventDataContext : DbContext
    {
        public EventDataContext(DbContextOptions<EventDataContext> options)
            : base(options)
        {
        }

        public DbSet<EventData> EventDatas { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}