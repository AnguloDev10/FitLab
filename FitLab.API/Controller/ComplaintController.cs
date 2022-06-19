using Fitlab.Entities;
using FitLab.DataAccess;
using FitLab.Dto.Request;
using FitLab.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitLab.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComplaintController:ControllerBase
    {
        private readonly IComplaintService _complaintService;

        public ComplaintController(IComplaintService complaintService)
        {
            _complaintService = complaintService;
        }

        [HttpPost]
        public async Task Post([FromBody] ComplaintDTO request)
        {
            await _complaintService.Create(request);
        }
        [HttpGet]
        public async Task<ActionResult<List<Complaint>>> Get()
        {
            return await _complaintService.ListAsync();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ComplaintDTO request)
        {

            await _complaintService.Update(id, request);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _complaintService.Delete(id);
            return NoContent();
        }


    }
}
