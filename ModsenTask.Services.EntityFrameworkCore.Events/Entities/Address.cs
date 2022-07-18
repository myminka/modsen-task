using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace ModsenTask.Services.EntityFrameworkCore.Events.Entities
{
    public class Address
    {
        [Column("id")]
        [JsonIgnore]
        public int Id { get; set; }

        [Column("country")]
        public string Country { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("street")]
        public string Street { get; set; }

        [Column("house_number")]
        public int HouseNumber { get; set; }

        [Column("event_data_id")]
        [JsonIgnore]
        public int EventDataId { get; set; }

        [Column("event_data")]
        [JsonIgnore]
        public EventData EventData { get; set; }
    }
}