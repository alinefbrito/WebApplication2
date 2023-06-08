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
    public class TblLivroesController : ControllerBase
    {
        private readonly DbBibliotecaContext _context;

        public TblLivroesController(DbBibliotecaContext context)
        {
            _context = context;
        }

        // GET: api/TblLivroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblLivro>>> GetTblLivros()
        {
          if (_context.TblLivros == null)
          {
              return NotFound();
          }
            return await _context.TblLivros.ToListAsync();
        }

        // GET: api/TblLivroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblLivro>> GetTblLivro(short id)
        {
          if (_context.TblLivros == null)
          {
              return NotFound();
          }
            var tblLivro = await _context.TblLivros.FindAsync(id);

            if (tblLivro == null)
            {
                return NotFound();
            }

            return tblLivro;
        }

        // PUT: api/TblLivroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblLivro(short id, TblLivro tblLivro)
        {
            if (id != tblLivro.IdLivro)
            {
                return BadRequest();
            }

            _context.Entry(tblLivro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblLivroExists(id))
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

        // POST: api/TblLivroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblLivro>> PostTblLivro(TblLivro tblLivro)
        {
          if (_context.TblLivros == null)
          {
              return Problem("Entity set 'DbBibliotecaContext.TblLivros'  is null.");
          }
            _context.TblLivros.Add(tblLivro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblLivro", new { id = tblLivro.IdLivro }, tblLivro);
        }

        // DELETE: api/TblLivroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblLivro(short id)
        {
            if (_context.TblLivros == null)
            {
                return NotFound();
            }
            var tblLivro = await _context.TblLivros.FindAsync(id);
            if (tblLivro == null)
            {
                return NotFound();
            }

            _context.TblLivros.Remove(tblLivro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblLivroExists(short id)
        {
            return (_context.TblLivros?.Any(e => e.IdLivro == id)).GetValueOrDefault();
        }
    }
}
