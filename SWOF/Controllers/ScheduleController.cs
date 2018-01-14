using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SWOF.Core.Contract;
using SWOF.Core.Resources;

namespace SWOF.Controllers
{

    [Route("api/[controller]")]
    public class ScheduleController : Controller
    {
        private static string[] _dayNames = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };

        private readonly IScheduleGeneratorService _scheduleGeneratorService;
        private readonly IOptions<ScheduleOptions> _optionsAccessor;

        public ScheduleController(IScheduleGeneratorService scheduleGeneratorService,
          IOptions<ScheduleOptions> optionsAccessor)
        {
            _scheduleGeneratorService = scheduleGeneratorService;
            _optionsAccessor = optionsAccessor;
        }


        public IActionResult Generate()
        {
            var shifts = _scheduleGeneratorService.Generate(_optionsAccessor.Value.ShiftsPerPeriod, _optionsAccessor.Value.ShiftsPerEngineerPerPeriod);

            // TODO create a Mapper profile for this
            // Map the shifts to the Day View Model
            var shiftsPerDay = _optionsAccessor.Value.ShiftsPerPeriod / _optionsAccessor.Value.ShiftDays;
            var days = new List<DayView>();
            for (int i = 0; i < _optionsAccessor.Value.ShiftDays; i++)
            {
                days.Add(new DayView
                {
                    Name = _dayNames[i % 5],
                    Shifts = shifts.Skip(i * shiftsPerDay).Take(shiftsPerDay).ToList(),
                    WeekNumber = i < 5 ? 1 : 2
                });
            }

            return Json(new Schedule { Days = days });
        }
    }
}