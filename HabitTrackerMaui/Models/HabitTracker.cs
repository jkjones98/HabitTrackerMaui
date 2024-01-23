using System.ComponentModel;
using SQLite;

namespace HabitTrackerMaui.Models
{
    [Table("runTracker")]
    public class RunTracker
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id {get; set;}
        public DateTime DateRun {get; set;}
        public int MinutesRan {get; set;}
        public int DistanceRan {get; set;}
    }
}