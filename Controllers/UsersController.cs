using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicDating.Data;
using MusicDating.Models.Entities;
using MusicDating.Models.ViewModels;

namespace MusicDating.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public async Task<IActionResult> Index(string instrumentName, string genreName)
        {
            // Do some coding - filter users to only display those who play the instrument
            // Get list of instruments
            var users = from u in _context.UserInstruments.Include(u => u.UserInstrumentGenres).Include(u => u.ApplicationUser).Include(u => u.Instrument)
                        select u;

            var genres = from g in _context.UserInstrumentGenres.Include(g => g.Genre)
                         select g.Genre;

            if (!string.IsNullOrEmpty(instrumentName))
            {
                users = users.Where(u => u.Instrument.Name == instrumentName);
            }

            if (!string.IsNullOrEmpty(genreName))
            {
                // Filter some shit here
            }

            var userInstrumentVM = new UserInstrumentVm
            {
                UserInstruments = await users.Distinct().ToListAsync(),
                Instruments = new SelectList(await _context.Instruments.ToListAsync(), "Name", "Name"),
                Genres = new SelectList(await _context.Genres.ToListAsync(), "GenreName", "GenreName"),
                InstrumentName = instrumentName,
                GenreName = genreName
                // UserInstrumentGenre = await userInstruments.ToListAsync(),
                // Genres = new SelectList(await genreQuery.Distinct().ToListAsync())
            };

            return View(userInstrumentVM);
        }
    }
}
