using Fitlab.Entities;
using FitLab.Dto.Request;
using FitLab.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitLab.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {

        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ScheduleDTO resource)
        {
            if (!ModelState.IsValid)
                return BadRequest("rataaaaaaa");

            Schedule newSchedule = new Schedule { StartAt=resource.StartAt,EndAt=resource.EndAt,State=resource.State,ProfileId=resource.UserId};
            var result = await _scheduleService.SaveAsync(newSchedule);

            if (!result.Success)
                return BadRequest(result.Message);

            //var scheduleResource = _mapper.Map<Schedule, ScheduleResource>(result.Resource);
            return Ok(newSchedule);
        }

        [HttpGet]
        public async Task<IEnumerable<Schedule>> GetAllAsync()
        {
            var schedules = await _scheduleService.ListAsync();
            return schedules;
        }

    }
}
