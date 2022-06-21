using Fitlab.Entities;
using FitLab.DataAccess;
using FitLab.Dto.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitLab.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProfileController:ControllerBase
    {
        private readonly FitLabDbContext _context;
     
        public ProfileController(FitLabDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Profile>> GetAsync(int id)
        {
            Profile profile = new Profile();
            try
            {
                profile = await _context.Profiles.Where(p => p.Id == id).FirstAsync();
                if (profile == null)
                {
                    throw new Exception("No se encontró ese perfil");
                }
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Invalid Username or Password" });
            }
            return Ok(profile);
        }


        [HttpGet]
        public async Task<ActionResult<Profile>> GetAllAsync()
        {
            List<Profile> profile = new List<Profile>();
            try
            {
                profile = await _context.Profiles.ToListAsync();
                if (profile == null)
                {
                    throw new Exception("No se encontró ese perfil");
                }
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Invalid Username or Password" });
            }
            return Ok(profile);
        }


        //POST
        [HttpPost]
        public async Task<ActionResult> Post ([FromBody] ProfileDTO request)
        {
            Account account = new Account();    

            Profile profile = new Profile { Name = request.Name, Email = request.Email, LastName= request.LastName, Rol= request.Rol, Password = request.Password, Age = request.Age,Phone = request.Phone };

            try
            {
               _context.Profiles.Add(profile);
                await _context.SaveChangesAsync();

                account.UserName = profile.Email;
                account.Password = profile.Password;
                account.ProfileId = profile.Id;
                account.Email = profile.Email;
                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();  
            }
            catch(Exception)
            {
                Console.WriteLine(profile.ToString());
                return BadRequest(new { message = "No se pudo Crear" });
            }
             return Ok(profile);    

        }
        //PUT
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, ProfileDTO request)
        {
            var entity = await _context.Profiles.FindAsync(id);
            if (entity == null) return NotFound();
            entity.Phone = request.Phone;
            entity.Name = request.Name;
            entity.Age = request.Age;
            entity.LastName = request.LastName;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new
            {
                Id = id
            });
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await _context.Profiles.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            
            return Ok(entity);
        }
    }
}
