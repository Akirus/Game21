using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Game21.Data.Models
{
    public class Stats
    {
        
        [Key, ForeignKey("Player")]
        public String PlayerId { get; set; }
        public Player Player { get; set; }
        
        public DateTimeOffset LastVisit { get; set; }
        
        public int TotalVisits { get; set; }
        
        public int WinsCount { get; set; }
        public int DefeatsCount { get; set; }

        [NotMapped]
        public double WinRate => WinsCount / (double)(WinsCount + DefeatsCount);
    }
}