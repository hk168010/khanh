using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Asm02_KhanhHCE150703.Data;
using Asm02_KhanhHCE150703.Model;

namespace Asm02_KhanhHCE150703.Pages.MovieGenre
{
    public class EditModel : PageModel
    {
        private readonly Asm02_KhanhHCE150703.Data.MovieDBContext _context;

        public EditModel(Asm02_KhanhHCE150703.Data.MovieDBContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MovieGenres).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieGenresExists(MovieGenres.MovieGenreID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MovieGenresExists(string id)
        {
            return _context.MovieGenres.Any(e => e.MovieGenreID == id);
        }
    }
}
