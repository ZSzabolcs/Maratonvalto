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

        [HttpPut("alterFuto")]
        public async Task<ActionResult<IEnumerable<Futok>>> AlterFuto(int id, int kor, int modositIdo)
        {
            var eredmeny = _context.Eredmenyek.Where(e => e.Futo == id && e.Kor == kor);

            if (eredmeny != null)
            {
                
            }
        }
    }
}
