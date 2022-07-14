using System;
using System.Collections.Generic;
using System.Text;

namespace ModsenTask.Services.EntityFrameworkCore.Events.Entities
{
    public class Address
    {
        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int HouseNumber { get; set; }

        public int EventDataId { get; set; }

        public EventData EventData { get; set; }
    }
}