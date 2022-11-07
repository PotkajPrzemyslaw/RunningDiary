using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunningDiary.Database
{
    public class Exercise : BaseEntity
    {
        public string Name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Distance { get; set; }

        [ForeignKey("Workout")]
        public int WorkoutId { get; set; }

        public virtual Workout Workout { get; set; }
    }
}
