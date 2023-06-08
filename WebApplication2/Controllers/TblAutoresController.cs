using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.DataContext;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblAutoresController : ControllerBase
    {
        private readonly DbBibliotecaContext _context;

        public TblAutoresController(DbBibliotecaContext context)
        {
            _context = context;
        }

        // GET: api/TblAutores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblAutore>>> GetTblAutores()
        {
          if (_context.TblAutores == null)
          {
              return NotFound();
          }
            return await _context.TblAutores.ToListAsync();
        }

        // GET: api/TblAutores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblAutore>> GetTblAutore(short id)
        {
          if (_context.TblAutores == null)
          {
              return NotFound();
          }
            var tblAutore = await _context.TblAutores.FindAsync(id);

            if (tblAutore == null)
            {
                return NotFound();
            }

            return tblAutore;
        }

        // PUT: api/TblAutores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblAutore(short id, TblAutore tblAutore)
        {
            if (id != tblAutore.IdAutor)
            {
                return BadRequest();
            }

            _context.Entry(tblAutore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblAutoreExists(id))
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

        // POST: api/TblAutores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblAutore>> PostTblAutore(TblAutore tblAutore)
        {
          if (_context.TblAutores == null)
          {
              return Problem("Entity set 'DbBibliotecaContext.TblAutores'  is null.");
          }
            _context.TblAutores.Add(tblAutore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblAutore", new { id = tblAutore.IdAutor }, tblAutore);
        }

        // DELETE: api/TblAutores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblAutore(short id)
        {
            if (_context.TblAutores == null)
            {
                return NotFound();
            }
            var tblAutore = await _context.TblAutores.FindAsync(id);
            if (tblAutore == null)
            {
                return NotFound();
            }

            _context.TblAutores.Remove(tblAutore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblAutoreExists(short id)
        {
            return (_context.TblAutores?.Any(e => e.IdAutor == id)).GetValueOrDefault();
        }
    }
}
