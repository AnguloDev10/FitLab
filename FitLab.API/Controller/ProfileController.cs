﻿using Fitlab.Entities;
using FitLab.DataAccess;
using FitLab.Dto.Request;
using FitLab.Services;
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
        private readonly IProfileService _profileService;
        public ProfileController(FitLabDbContext context, IProfileService profileService)
        {
            _context = context;
            _profileService = profileService;
        }
        //POST
        [HttpPost]
        public async Task<ActionResult> Post ([FromBody] ProfileDTO request)
        {
            Account account = new Account();    

            Profile profile = new Profile { Name = request.Name, Email = request.Email, LastName= request.LastName, Rol= request.Rol, Password = request.Password, Age = request.Age,Phone = request.Phone };

            try
            {
               await  _profileService.Create(profile);

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
            await _profileService.Update(entity);
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

        [HttpGet]
        public async Task<ActionResult<List<Profile>>> Get()
        {
            return await _profileService.ListAsync();
        }

        [HttpGet("{id}", Name = "GetProfile")]
        public async Task<ActionResult<Profile>> Get(int id)
        {
            var profile = await _profileService.GetAsync(id);

            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

    }
}
