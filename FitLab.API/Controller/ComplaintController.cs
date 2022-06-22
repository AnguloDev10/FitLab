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

        [HttpGet]
        public async Task<IEnumerable<Complaint>> GetAllAsync()
        {
            var complaints = await _complaintService.ListAsync();
            return complaints;
        }

        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ComplaintDTO resource)
        {
            if (!ModelState.IsValid)
                return BadRequest("Digite bien los datos");

            var newComplaint = new Complaint { Description= resource.Description,UserId=resource.UserId,Name = resource.Name};

        
          var result = await _complaintService.SaveAsync(newComplaint);
          
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(newComplaint);
        }

        
        [HttpPut("{id}")]
      
        public async Task<IActionResult> PutAsync(int id, [FromBody] ComplaintDTO resource)
        {

            var result = await _complaintService.UpdateAsync(id, resource);

          //  if (!result.Success)
             //   return BadRequest(result.Message);
         //   var complaintResource = _mapper.Map<Complaint, ComplaintResource>(result.Resource);
            return Ok();
        }


        
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> DeleteAsync(int id)
        {
          //  var result = await _complaintService.DeleteAsync(id);
          //  if (!result.Success)
         //   {
               
          //  }
          //  try
          //  {

        //    }
          //  catch ()
          //  {
         //       return BadRequest(result.Message);
         //   }
                
         //   var complaintResource = _mapper.Map<Complaint, ComplaintResource>(result.Resource);
            return Ok();
        }


    }
}
