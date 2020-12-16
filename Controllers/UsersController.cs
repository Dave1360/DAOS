using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicDating.Data;
using MusicDating.Models.Entities;
using MusicDating.Models.Services;
using MusicDating.Models.ViewModels;

namespace MusicDating.Controllers
{
    public class UsersController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet()]
        public async Task<IActionResult> Index(int instrumentId, int genreId)
        {
            // Do some coding - filter users to only display those who play the instrument
            // Get list of instruments
            UserInstrumentVm userInstrumentVM = await UserServices.SearchForUsers(_context, instrumentId, genreId);

            return View(userInstrumentVM);
        }

        // GET: User/Profile
        public async Task<IActionResult> Profile(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = from u in _context.ApplicationUsers
            .Include(u => u.Profile)
            .Include(u => u.UserInstruments).ThenInclude(u => u.UserInstrumentGenres).ThenInclude(u => u.Genre).ThenInclude(u => u.GenreEnsembles)
            .Include(u => u.UserInstruments).ThenInclude(u => u.Instrument)
                       select u;

            // var user = await _context.Users
            //     .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            if (!String.IsNullOrEmpty(id))
            {
                user = from u in user
                       where u.Id == id
                       select u;
            }


            return View(await user.ToListAsync());
        }

        // GET: Profile/Edit/
        public async Task<IActionResult> Edit(string id)
        {

            var user = from u in _context.ApplicationUsers
                        .Include(u => u.Profile)
                       select u;

            if (!String.IsNullOrEmpty(id))
            {
                user = from u in user
                       where u.Id == id
                       select u;
            }

            if (user == null)
            {
                return NotFound();
            }

            return View(await user.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("user.Id,user.FirstName,user.LastName,user.Email")] ApplicationUser applicationUser, [Bind("user.Profile.Description,user.Profile.Address,user.Profile.PhoneNumber")] Profile profile)
        {
            if (id != applicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationUser);
                    _context.Update(profile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        private bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUsers.Any(e => e.Id == id);
        }
    }
}
