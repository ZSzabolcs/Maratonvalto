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
                return NotFound("Nem található ilyen nevű szerző.");
            }

            return BadRequest();
        }
    }
}
