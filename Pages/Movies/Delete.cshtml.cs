﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Asm02_KhanhHCE150703.Data;
using Asm02_KhanhHCE150703.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asm02_KhanhHCE150703.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        private readonly Asm02_KhanhHCE150703.Data.MovieDBContext _context;

        public DeleteModel(Asm02_KhanhHCE150703.Data.MovieDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            ViewData["MovieGenreName"] = new SelectList(_context.MovieGenres, "MovieGenreID", "MovieGenreName");
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movies.FirstOrDefaultAsync(m => m.MovieID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movies.FindAsync(id);

            if (Movie != null)
            {
                _context.Movies.Remove(Movie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
