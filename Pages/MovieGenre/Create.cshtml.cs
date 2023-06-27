using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Asm02_KhanhHCE150703.Data;
using Asm02_KhanhHCE150703.Model;

namespace Asm02_KhanhHCE150703.Pages.MovieGenre
{
    public class CreateModel : PageModel
    {
        private readonly Asm02_KhanhHCE150703.Data.MovieDBContext _context;

        public CreateModel(Asm02_KhanhHCE150703.Data.MovieDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MovieGenres MovieGenres { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MovieGenres.Add(MovieGenres);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
