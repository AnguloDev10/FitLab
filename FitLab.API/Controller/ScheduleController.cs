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
        private readonly IScheduleService _ScheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _ScheduleService = scheduleService;
        }
        [HttpPost]
        public async Task Post([FromBody] ScheduleDTO request)
        {
            await _ScheduleService.Create(request);
        }
        [HttpGet]
        public async Task<ActionResult<List<Schedule>>> Get()
        {
            return await _ScheduleService.ListAsync();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ScheduleDTO request)
        {

            await _ScheduleService.Update(id, request);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _ScheduleService.Delete(id);
            return NoContent();
        }

    }
}
