using Fitlab.Entities;
using FitLab.Dto.Request;
using FitLab.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitLab.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceService _experienceService;

        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }
        [HttpPost]
        public async Task Post([FromBody] ExperienceDTO request)
        {
            await _experienceService.Create(request);
        }
        [HttpGet]
        public async Task<ActionResult<List<Experience>>> Get()
        {
            return await _experienceService.ListAsync();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ExperienceDTO request)
        {

            await _experienceService.Update(id, request);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _experienceService.Delete(id);
            return NoContent();
        }
    }
}
