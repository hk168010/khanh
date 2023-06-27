using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Asm02_KhanhHCE150703.Data;
using Asm02_KhanhHCE150703.Model;

namespace Asm02_KhanhHCE150703.Pages.MovieGenre
{
    public class DetailsModel : PageModel
    {
        private readonly Asm02_KhanhHCE150703.Data.MovieDBContext _context;

        public DetailsModel(Asm02_KhanhHCE150703.Data.MovieDBContext context)
        {
            _context = context;
        }

        public MovieGenres MovieGenres { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MovieGenres = await _context.MovieGenres.FirstOrDefaultAsync(m => m.MovieGenreID == id);

            if (MovieGenres == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
