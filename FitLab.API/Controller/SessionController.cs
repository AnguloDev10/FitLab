using Fitlab.Entities;
using FitLab.Dto.Request;
using FitLab.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitLab.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController:ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }
        [HttpPost]
        public async Task Post([FromBody] SessionDTO request)
        {
            await _sessionService.Create(request);
        }
        [HttpGet]
        public async Task<ActionResult<List<Session>>> Get()
        {
            return await _sessionService.ListAsync();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] SessionDTO request)
        {

            await _sessionService.Update(id, request);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _sessionService.Delete(id);
            return NoContent();
        }

    }
}
