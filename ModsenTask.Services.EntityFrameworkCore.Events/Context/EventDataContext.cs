using Microsoft.EntityFrameworkCore;
using ModsenTask.Services.EntityFrameworkCore.Events.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModsenTask.Services.EntityFrameworkCore.Events.Context
{
    public class EventDataContext : DbContext
    {
        public DbSet<EventData> eventDatas { get; set; }
        public DbSet<Address> addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EventData;Trusted_Connection=True;");
        }
    }
}
