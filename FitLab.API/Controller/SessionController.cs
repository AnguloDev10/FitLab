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
           this._sessionService = sessionService;
        }


        [HttpPost]
        public async Task<ActionResult<Session>> PostAsync([FromBody] SessionDTO resource)
        {
            Session newSession = new Session { StartAt=resource.StartAt,EndAt=resource.EndAt,ProfileId=resource.UserId,Link=resource.Link};
            var result = await _sessionService.SaveAsync(newSession);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(newSession);
        }

        [HttpGet]
        public async Task<IEnumerable<Session>> GetAllAsync()
        {
            var sessions = await _sessionService.ListAsync();
            return sessions;
        }


    }
}
