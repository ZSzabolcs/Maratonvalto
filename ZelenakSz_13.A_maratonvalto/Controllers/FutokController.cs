using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mysqlx;
using ZelenakSz_13.A_maratonvalto.Models;

namespace ZelenakSz_13.A_maratonvalto.Controllers
{
    public class FutokController : Controller
    {
        private readonly MaratonContext _context;

        public FutokController(MaratonContext context)
        {
            _context = context;
        }

        [HttpGet("searhFutok")]
        public async Task<ActionResult<IEnumerable<Futok>>> GetFutok()
        {
            var futok = _context.Futok.Include(e => e.Eredmenyek).ToList();

            if (futok != null)
            {
                return Ok(futok);
            }

            return BadRequest();
        }

        [HttpGet("searhFuto")]
        public async Task<ActionResult<IEnumerable<Futok>>> GetFuto(string name)
        {
            var futok = _context.Futok.Include(e => e.Eredmenyek).Where(a => a.Fnev == name).ToList();

            if (futok != null)
            {
                return Ok(futok);
            }

            if (!futok.Any() || futok == null)
            {
                return NotFound("Nem található ilyen nevű futó.");
            }

            return BadRequest();
        }

        [HttpGet("searchNok")]
        public async Task<ActionResult> GetNok()
        {
            var futok = _context.Futok.Where(f => f.Ffi == false).ToList();

            if (futok != null)
            {
                var eredmeny = futok.Select(f => new { f.Fnev, f.Szulev }).OrderBy(f => f.Fnev).ToList();
                return Ok(eredmeny);
            }

            if (futok == null)
            {
                return NotFound("Nem található női futó.");
            }

            return BadRequest();
        }

        [HttpDelete("deleteFuto")]
        public async Task<ActionResult<IEnumerable<Futok>>> DeleteFuto(int id)
        {
            var futo = await _context.Futok.FirstOrDefaultAsync(f => f.Fid == id);

            if (futo != null)
            {
                _context.Remove(futo);
                _context.SaveChanges();
                return Ok("Sikeres törlés!");
            }

            if (futo == null)
            {
                return NotFound("Nem található ilyen futó.");
            }

            return BadRequest();
        }
    }
}
