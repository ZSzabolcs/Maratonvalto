using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    }
}
