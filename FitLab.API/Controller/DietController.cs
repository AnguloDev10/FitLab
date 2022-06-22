using Fitlab.Entities;
using FitLab.Dto.Request;
using FitLab.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitLab.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class DietController:ControllerBase
    {
        private readonly IDietService _dietService;

        public DietController(IDietService dietService)
        {
            _dietService = dietService;
        }
        [HttpGet]
        public async Task<IEnumerable<Diet>> GetAllAsync()
        {
            var diets = await _dietService.ListAsync();
            return diets;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] DietDTO resource)
        {
            if (!ModelState.IsValid)
                return BadRequest("Malardo");
            Diet newDiet = new Diet { Description=resource.Description,Title=resource.Title,SessionId=resource.SessionId };
            var result = await _dietService.SaveAsync(newDiet);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(newDiet);
        }
        [HttpGet("{sessionId}")]
        public async Task<IEnumerable<Diet>> GetDietsBySessionId(int sessionId)
        {
            var diets = await _dietService.ListBySessionIdAsync(sessionId);
            return diets;
        }

    }
}
