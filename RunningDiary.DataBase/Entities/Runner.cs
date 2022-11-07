using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunningDiary.Database
{
    public class Runner : BaseEntity
    {
        [StringLength(50, MinimumLength = 3), Required]
        public string FirstName { get; set; }
        [StringLength(50, MinimumLength = 3), Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }

        [NotMapped]
        public virtual ICollection<Workout> Workouts { get; set; }
    }
}
