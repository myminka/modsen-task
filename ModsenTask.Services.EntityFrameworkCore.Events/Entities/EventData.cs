using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModsenTask.Services.EntityFrameworkCore.Events.Entities
{
    public class EventData
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [Column("discription", TypeName = "ntext")]
        public string Description { get; set; }

        [Column("organiser")]
        public string Organiser { get; set; }

        [Column("address")]
        public Address Address { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }
    }
}