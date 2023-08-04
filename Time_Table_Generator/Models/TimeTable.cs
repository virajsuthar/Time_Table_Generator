using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Time_Table_Generator.Models
{
    public class TimeTable
    {
        [Required(ErrorMessage = "Please enter the number of working days.")]
        [Range(1, 7, ErrorMessage = "Number of working days must be between 1 and 7.")]
        public int TotalWorkingDays { get; set; }

        [Required(ErrorMessage = "Please enter the number of subjects per day.")]
        [Range(1, 8, ErrorMessage = "Number of subjects per day must be between 1 and 8.")]
        public int TotalSubjectsPerDay { get; set; }

        [Required(ErrorMessage = "Please enter the total number of subjects.")]
        [Range(1, int.MaxValue, ErrorMessage = "Total subjects must be a positive number.")]
        public int TotalSubjects { get; set; }

    }
}