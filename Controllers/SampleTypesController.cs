using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabAPI.Models;

namespace LabAPI.Controllers
{
    [Route("apiSampleTypes")]
    [ApiController]
    public class SampleTypesController : ControllerBase
    {
        private readonly dbLabContext _context;

        public SampleTypesController(dbLabContext context)
        {
            _context = context;
        }

        // GET: api/SampleTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SampleType>>> GetSampleType()
        {
            return await _context.SampleType.ToListAsync();
        }

        // GET: api/SampleTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SampleType>> GetSampleType(int id)
        {
            var sampleType = await _context.SampleType.FindAsync(id);

            if (sampleType == null)
            {
                return NotFound();
            }

            return sampleType;
        }

        // PUT: api/SampleTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSampleType(int id, SampleType sampleType)
        {
            if (id != sampleType.TypeID)
            {
                return BadRequest();
            }

            _context.Entry(sampleType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SampleTypeExists(id))
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

        // POST: api/SampleTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SampleType>> PostSampleType(SampleType sampleType)
        {
            _context.SampleType.Add(sampleType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSampleType", new { id = sampleType.TypeID }, sampleType);
        }

        // DELETE: api/SampleTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSampleType(int id)
        {
            var sampleType = await _context.SampleType.FindAsync(id);
            if (sampleType == null)
            {
                return NotFound();
            }

            _context.SampleType.Remove(sampleType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SampleTypeExists(int id)
        {
            return _context.SampleType.Any(e => e.TypeID == id);
        }
    }
}
