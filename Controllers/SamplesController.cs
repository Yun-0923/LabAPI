using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabAPI.Models;
using LabAPI.DTO;
using System.Drawing.Drawing2D;
using Microsoft.CodeAnalysis;

namespace LabAPI.Controllers
{
    [Route("apiSamples")]
    [ApiController]
    public class SamplesController : ControllerBase
    {
        private readonly dbLabContext _context;

        public SamplesController(dbLabContext context)
        {
            _context = context;
        }

        // GET: api/Samples
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SamplesDTO>>> GetSamples(int typeID)
        {
            var result = _context.Samples.Where(s=>s.TypeID == typeID).Select(s=> new SamplesDTO
            {
                SampleID = s.SampleID,
                SampleName = s.SampleName,
                Species = s.Species == null ? "" : s.Species,
                Genotype = s.Genotype == null ? "" : s.Genotype,
                Serotype = s.Serotype,
                Quantity = s.Quantity,
            });
            return await result.ToListAsync();
        }

        // GET: api/Samples/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Samples>> GetSamples(long id)
        {
            var samples = await _context.Samples.FindAsync(id);

            if (samples == null)
            {
                return NotFound();
            }

            return samples;
        }

        // PUT: api/Samples/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSamples(long id, Samples samples)
        {
            if (id != samples.SampleID)
            {
                return BadRequest();
            }

            _context.Entry(samples).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SamplesExists(id))
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

        // POST: api/Samples
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Samples>> PostSamples(Samples samples)
        {
            _context.Samples.Add(samples);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSamples", new { id = samples.SampleID }, samples);
        }

        // DELETE: api/Samples/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSamples(long id)
        {
            var samples = await _context.Samples.FindAsync(id);
            if (samples == null)
            {
                return NotFound();
            }

            _context.Samples.Remove(samples);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SamplesExists(long id)
        {
            return _context.Samples.Any(e => e.SampleID == id);
        }
    }
}
