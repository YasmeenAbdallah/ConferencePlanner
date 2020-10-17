using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SpeakersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Speakers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Speakers>>> GetSpeakers()
        {
            return await _context.Speakers.ToListAsync();
        }

        // GET: api/Speakers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Speakers>> GetSpeakers(int id)
        {
            var speakers = await _context.Speakers.FindAsync(id);

            if (speakers == null)
            {
                return NotFound();
            }

            return speakers;
        }

        // PUT: api/Speakers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpeakers(int id, Speakers speakers)
        {
            if (id != speakers.Id)
            {
                return BadRequest();
            }

            _context.Entry(speakers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpeakersExists(id))
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

        // POST: api/Speakers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Speakers>> PostSpeakers(Speakers speakers)
        {
            _context.Speakers.Add(speakers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpeakers", new { id = speakers.Id }, speakers);
        }

        // DELETE: api/Speakers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Speakers>> DeleteSpeakers(int id)
        {
            var speakers = await _context.Speakers.FindAsync(id);
            if (speakers == null)
            {
                return NotFound();
            }

            _context.Speakers.Remove(speakers);
            await _context.SaveChangesAsync();

            return speakers;
        }

        private bool SpeakersExists(int id)
        {
            return _context.Speakers.Any(e => e.Id == id);
        }
    }
}
