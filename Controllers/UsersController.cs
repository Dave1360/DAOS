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
        public async Task<IActionResult> Index(string instrumentName)
        {
            // Do some coding - filter users to only display those who play the instrument
            // Get list of instruments
            IQueryable<string> instrumentQuery = from m in _context.Instruments
                                                 select m.Name;


            var userInstruments = from x in _context.UserInstruments
                                  select x;

            userInstruments = userInstruments.Include(x => x.Instrument).Include(x => x.ApplicationUser);


            if (!string.IsNullOrEmpty(instrumentName))
            {
                userInstruments = userInstruments.Where(x => x.Instrument.Name == instrumentName);
            }

            var userInstrumentVM = new UserInstrumentVm
            {
                Instruments = new SelectList(await instrumentQuery.Distinct().ToListAsync()),
                UserInstrument = await userInstruments.ToListAsync()
            };

            return View(userInstrumentVM);
        }
    }
}
