using Fitlab.Entities;
using FitLab.Dto.Request;
using FitLab.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitLab.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;
        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpPost]
        public async Task Post([FromBody] SubscriptionDTO request)
        {
            await _subscriptionService.Create(request);
        }

        [HttpGet]
        public async Task<ActionResult<List<Subscription>>> Get()
        {
            return await _subscriptionService.ListAsync();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] SubscriptionDTO request)
        {

            await _subscriptionService.Update(id, request);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _subscriptionService.Delete(id);
            return NoContent();
        }
    }
}
