using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Crud_Operations.Data;
using Crud_Operations.Models;

namespace Crud_Operations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProfileController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/JobSeekerSignup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfileModel>>> GetProfile()
        {
            return await _context.Profile.ToListAsync();
        }

        // GET: api/JobSeekerSignup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileModel>> GetProfileModel(int id)
        {
            var profileModel = await _context.Profile.FindAsync(id);

            if (profileModel == null)
            {
                return NotFound();
            }

            return profileModel;
        }

        // PUT: api/JobSeekerSignup/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfileModel(int id, ProfileModel profileModel)
        {
            if (id != profileModel.JobSeekerRegistrationID)
            {
                return BadRequest();
            }

            _context.Entry(profileModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/JobSeekerSignup
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProfileModel>> PostProfileModel( [FromBody]ProfileModel profileModel)
        {
            _context.Profile.Add(profileModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfileModel", new { id = profileModel.JobSeekerRegistrationID }, profileModel);
        }

        // DELETE: api/JobSeekerSignup/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfileModel(int id)
        {
            var profileModel = await _context.Profile.FindAsync(id);
            if (profileModel == null)
            {
                return NotFound();
            }

            _context.Profile.Remove(profileModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfileModelExists(int id)
        {
            return _context.Profile.Any(e => e.JobSeekerRegistrationID == id);
        }

    }
}