using FitLab.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace FitLab.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComplaintController
    {
        private readonly FitLabDbContext _context;

        public ComplaintController(FitLabDbContext context)
        {
            _context = context;
        }





    }
}
