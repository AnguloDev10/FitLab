using Fitlab.Entities;
using FitLab.Dto.Request;
using FitLab.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitLab.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class DietController : ControllerBase
    {
        private readonly IDietService _dietService;

        public DietController(IDietService dietService)
        {
            _dietService = dietService;
        }
        [HttpPost]
        public async Task Post([FromBody] DietDTO request)
        {
            await _dietService.Create(request);
        }
        [HttpGet]
        public async Task<ActionResult<List<Diet>>> Get()
        {
            return await _dietService.ListAsync();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] DietDTO request)
        {

            await _dietService.Update(id, request);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _dietService.Delete(id);
            return NoContent();
        }
    }
}
