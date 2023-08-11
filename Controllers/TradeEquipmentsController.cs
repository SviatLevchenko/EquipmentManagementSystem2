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
    public class TradeEquipmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TradeEquipmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TradeEquipments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TradeEquipment>>> GetTradeEquipments()
        {
          if (_context.TradeEquipments == null)
          {
              return NotFound();
          }
            return await _context.TradeEquipments.ToListAsync();
        }

        // GET: api/TradeEquipments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TradeEquipment>> GetTradeEquipment(int id)
        {
          if (_context.TradeEquipments == null)
          {
              return NotFound();
          }
            var tradeEquipment = await _context.TradeEquipments.FindAsync(id);

            if (tradeEquipment == null)
            {
                return NotFound();
            }

            return tradeEquipment;
        }

        // PUT: api/TradeEquipments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTradeEquipment(int id, TradeEquipment tradeEquipment)
        {
            if (id != tradeEquipment.ID)
            {
                return BadRequest();
            }

            _context.Entry(tradeEquipment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TradeEquipmentExists(id))
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

        // POST: api/TradeEquipments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TradeEquipment>> PostTradeEquipment(TradeEquipment tradeEquipment)
        {
          if (_context.TradeEquipments == null)
          {
              return Problem("Entity set 'ApplicationDbContext.TradeEquipments'  is null.");
          }
            _context.TradeEquipments.Add(tradeEquipment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTradeEquipment", new { id = tradeEquipment.ID }, tradeEquipment);
        }

        // DELETE: api/TradeEquipments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTradeEquipment(int id)
        {
            if (_context.TradeEquipments == null)
            {
                return NotFound();
            }
            var tradeEquipment = await _context.TradeEquipments.FindAsync(id);
            if (tradeEquipment == null)
            {
                return NotFound();
            }

            _context.TradeEquipments.Remove(tradeEquipment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TradeEquipmentExists(int id)
        {
            return (_context.TradeEquipments?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
