using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Asm02_KhanhHCE150703.Data;
using Asm02_KhanhHCE150703.Model;

namespace Asm02_KhanhHCE150703.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly Asm02_KhanhHCE150703.Data.MovieDBContext _context;

        public IndexModel(/*Asm02_KhanhHCE150703.Data.MovieDBContext context*/)
        {
            //_context = context;
        }
        public IActionResult OnGetGetMovies()
        {
            //var movie = _context.Movies.ToList();
            var movie = new List<Movie>
            {
            new Movie{MovieID="1",MovieName="ABC",Rating=5,RunningTime=120,Year=2020, MovieGenreID="123" },
            new Movie{MovieID="2",MovieName="XYZ",Rating=5,RunningTime=120,Year=2020, MovieGenreID="123" },
            new Movie{MovieID="3",MovieName="QWE",Rating=5,RunningTime=120,Year=2020, MovieGenreID="123" },
            new Movie{MovieID="4",MovieName="RTY",Rating=5,RunningTime=120,Year=2020, MovieGenreID="123" },
            };

            return new JsonResult(movie);
        }
        public IList<Movie> Movie { get; set; }
        public List<MovieGenres> MovieGenres { get; set; }

        public async Task OnGetAsync()
        {
            //Movie = await _context.Movies.ToListAsync();

            //MovieGenres = await _context.MovieGenres.ToListAsync();

        }
    }
}
