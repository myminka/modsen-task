using System;
using System.Collections.Generic;
using System.Text;

namespace ModsenTask.Services.EntityFrameworkCore.Events.Entities
{
    public class EventData
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Organiser { get; set; }

        public Address Address { get; set; }
    }
}
