using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Asm02_KhanhHCE150703.Data;
using Asm02_KhanhHCE150703.Model;
using Microsoft.AspNetCore.SignalR;


namespace Asm02_KhanhHCE150703.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly Asm02_KhanhHCE150703.Data.MovieDBContext _context;
        private readonly IHubContext<SignalrServer> _signalrHub;
        public CreateModel(Asm02_KhanhHCE150703.Data.MovieDBContext context, IHubContext<SignalrServer> signalrHub)
        {
            _context = context;
            _signalrHub = signalrHub;
        }

        public IActionResult OnGet()
        {
       
            ViewData["MovieGenreName"] = new SelectList(_context.MovieGenres, "MovieGenreID", "MovieGenreName");
      
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;
        [BindProperty]
        public MovieGenres movieGenres { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movies.Add(Movie);
            await _context.SaveChangesAsync();
            await _signalrHub.Clients.All.SendAsync("LoadMovies");

            return RedirectToPage("./Index");
        }
    }
}
