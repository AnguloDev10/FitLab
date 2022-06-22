using Fitlab.Entities;
using FitLab.DataAccess;
using FitLab.Dto.Request.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitLab.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController: ControllerBase
    {
        private readonly FitLabDbContext _context;

        //Constructor
        public AccountController(FitLabDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Profile>> Post([FromBody]  AuthenticationRequest request)
        {
            Profile profile = new Profile();
            try
            {
                var account =  GetByUserandPassword(request.UserName,request.Password);
                profile =  _context.Profiles.Find(account.ProfileId);
                Console.WriteLine(account.ProfileId);
                if(account == null)
                {
                    throw new Exception("No se encontro esta cuenta");
                }
            }
            catch(Exception)
            {
                return BadRequest(new { message = "Invalid Username or Password" });
            }
            return Ok(profile);
        }

        [HttpGet]
        public async Task<List<Account>> Get()
        {
            var accounts = await _context.Accounts.ToListAsync();
            return accounts;
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            var existingAccount = _context.Accounts.FirstOrDefault(c => c.Id == id);
            if (existingAccount == null)
                throw new Exception("No se encontro");
            try
            {
                _context.Accounts.Remove(existingAccount);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error");
            }
        }

        [NonAction]
        public Account GetByUserandPassword(string username, string password) =>
            _context.Accounts.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();
        /*   
        public Task<Profile> GetProfilebyAccountId(int Id) =>
            _context.Profiles.Where(x => x.Id == Id).FirstAsync();*/
    }
}
