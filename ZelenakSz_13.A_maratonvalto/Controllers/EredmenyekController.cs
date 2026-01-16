using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZelenakSz_13.A_maratonvalto.Models;

namespace ZelenakSz_13.A_maratonvalto.Controllers
{
    public class EredmenyekController : Controller
    {
        private readonly MaratonContext _context;

        public EredmenyekController(MaratonContext context)
        {
            _context = context;
        }

        [HttpPut("alterEredmeny")]
        public async Task<ActionResult> AlterEredmeny(int id, int kor, int modositIdo)
        {
            var eredmeny = _context.Eredmenyek.Where(e => e.Futo == id && e.Kor == kor).ToList();

            if (eredmeny != null)
            {
                foreach (var item in eredmeny)
                {
                    item.Ido = modositIdo;
                }
                _context.SaveChanges();
                return Ok("Sikeres módosítás!");
            }
            
            if (eredmeny == null || !eredmeny.Any())
            {
                return NotFound("Nem található ilyen futó.");
            }

            return BadRequest();
        }

        [HttpPost("addEredmeny")]
        public async Task<ActionResult> AddEredmeny(int id, int kor, int ido)
        {
            var eredmeny = new Eredmenyek(id, kor, ido);

            if (eredmeny != null)
            {
                _context.Eredmenyek.Add(eredmeny);
                _context.SaveChanges();
                return Ok("Sikeres felvétel!");
            }

            return BadRequest();
        }
    }
}
