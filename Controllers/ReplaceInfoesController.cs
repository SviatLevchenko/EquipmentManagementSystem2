using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EMS.Models;

namespace EMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReplaceInfoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReplaceInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ReplaceInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReplaceInfo>>> GetReplaceInfos()
        {
          if (_context.ReplaceInfos == null)
          {
              return NotFound();
          }
            return await _context.ReplaceInfos.ToListAsync();
        }

        // GET: api/ReplaceInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReplaceInfo>> GetReplaceInfo(int id)
        {
          if (_context.ReplaceInfos == null)
          {
              return NotFound();
          }
            var replaceInfo = await _context.ReplaceInfos.FindAsync(id);

            if (replaceInfo == null)
            {
                return NotFound();
            }

            return replaceInfo;
        }

        // PUT: api/ReplaceInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReplaceInfo(int id, ReplaceInfo replaceInfo)
        {
            if (id != replaceInfo.ID)
            {
                return BadRequest();
            }

            _context.Entry(replaceInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReplaceInfoExists(id))
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

        // POST: api/ReplaceInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReplaceInfo>> PostReplaceInfo(ReplaceInfo replaceInfo)
        {
          if (_context.ReplaceInfos == null)
          {
              return Problem("Entity set 'ApplicationDbContext.ReplaceInfos'  is null.");
          }
            _context.ReplaceInfos.Add(replaceInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReplaceInfo", new { id = replaceInfo.ID }, replaceInfo);
        }

        // DELETE: api/ReplaceInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReplaceInfo(int id)
        {
            if (_context.ReplaceInfos == null)
            {
                return NotFound();
            }
            var replaceInfo = await _context.ReplaceInfos.FindAsync(id);
            if (replaceInfo == null)
            {
                return NotFound();
            }

            _context.ReplaceInfos.Remove(replaceInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReplaceInfoExists(int id)
        {
            return (_context.ReplaceInfos?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
