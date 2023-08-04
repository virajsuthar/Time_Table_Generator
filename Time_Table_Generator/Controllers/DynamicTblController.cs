using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Time_Table_Generator.Models;

namespace Time_Table_Generator.Controllers
{
    public class DynamicTblController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Generate(int totalWorkingDays, int totalSubjectsPerDay, int totalSubjects)
        {
            List<Subject> subjects = new List<Subject>
            {
                new Subject { Name = "Gujarati", TotalHours = 3 },
                new Subject { Name = "English", TotalHours = 4 },
                new Subject { Name = "Science", TotalHours = 6 },
                new Subject { Name = "Maths", TotalHours = 7 }
            };

            if (totalWorkingDays <= 0 || totalWorkingDays > 7 || totalSubjectsPerDay <= 0 || totalSubjectsPerDay >= 9)
            {
                return RedirectToAction("Create");
            }

            int totalHoursForWeek = totalWorkingDays * totalSubjectsPerDay;

            if (subjects.Sum(s => s.TotalHours) != totalHoursForWeek)
            {
            //    return RedirectToAction("Create");
            }
            List<Subject> shuffledSubjects = subjects.OrderBy(s => Guid.NewGuid()).ToList();

            string[,] timeTable = new string[totalSubjectsPerDay, totalWorkingDays];

            int rowIndex = 0;
            int colIndex = 0;

            foreach (var subject in shuffledSubjects)
            {
                int subjectHoursPlaced = 0;

                while (subjectHoursPlaced < subject.TotalHours && colIndex < totalWorkingDays)
                {
                    timeTable[rowIndex, colIndex] = subject.Name;
                    rowIndex++;
                    if (rowIndex == totalSubjectsPerDay)
                    {
                        rowIndex = 0;
                        colIndex++;
                    }
                    subjectHoursPlaced++;
                }

                if (rowIndex == totalWorkingDays)
                {
                    break;
                }
            }

            ViewBag.TimeTable = timeTable;
            ViewBag.TotalWorkingDays = totalWorkingDays;
            ViewBag.TotalSubjectsPerDay = totalSubjectsPerDay;
            return View();
        }

    }
}
