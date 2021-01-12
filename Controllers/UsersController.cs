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

            // var user = await _context.ApplicationUsers.FindAsync(id);

            var user = await (from u in _context.ApplicationUsers
            .Include(u => u.Profile)
                              where u.Id == id
                              select u).FirstAsync();

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FirstName,LastName,PhoneNumber,Email,Profile")] ApplicationUser applicationUser)
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);

            var profile = await (from u in _context.Profiles
                                 where u.ProfileId == user.Id
                                 select u).FirstAsync();

            user.Profile = profile;

            user.FirstName = applicationUser.FirstName;
            user.LastName = applicationUser.LastName;
            user.PhoneNumber = applicationUser.PhoneNumber;
            user.Email = applicationUser.Email;


            user.Profile.Description = applicationUser.Profile.Description;
            user.Profile.City = applicationUser.Profile.City;
            user.Profile.ZipCode = applicationUser.Profile.ZipCode;
            user.Profile.Searching = applicationUser.Profile.Searching;


            if (applicationUser.Id != id)
            {
                Console.WriteLine("Not found");
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(applicationUser.Id))
                    {
                        Console.WriteLine("Does not exist");
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

        public async Task<IActionResult> AddUserInstrument(string id, int instrumentId, int genreId)
        {

            var user = await (from u in _context.ApplicationUsers
            .Include(u => u.Profile)
                              where u.Id == id
                              select u).FirstAsync();

            if (user == null)
            {
                return NotFound();
            }

            var AddUserInstrumentVm = new AddUserInstrumentVm
            {
                ApplicationUser = user,
                Instruments = new SelectList(await _context.Instruments.ToListAsync(), "InstrumentId", "Name"),
                Genres = new SelectList(await _context.Genres.ToListAsync(), "GenreId", "GenreName"),
                InstrumentId = instrumentId,
                GenreId = genreId
            };

            return View(AddUserInstrumentVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUserInstrument(string id, int[] genreId, [Bind("Id,InstrumentId,Level")] UserInstrument userInstrument)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    _context.Add(userInstrument);
                    foreach (var item in genreId)
                    {

                        var userInstrumentGenre = new UserInstrumentGenre { Id = id, InstrumentId = userInstrument.InstrumentId, GenreId = item };
                        _context.Add(userInstrumentGenre);
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw (ex);
                }
                return RedirectToAction("Profile", new { id = userInstrument.Id });
            }
            return View();
        }

        public async Task<IActionResult> EditUserInstrument(string id, int instrumentId, int genreId)
        {

            var user = await (from u in _context.UserInstruments
            .Include(u => u.UserInstrumentGenres).ThenInclude(u => u.Genre)
                              where u.Id == id && u.InstrumentId == instrumentId
                              select u).FirstAsync();

            var EditUserInstrumentVm = new EditUserInstrumentVm
            {
                UserInstrument = user,
                Genres = new SelectList(await _context.Genres.ToListAsync(), "GenreId", "GenreName"),
                GenreId = genreId

            };
            if (user == null)
            {
                return NotFound();
            }

            return View(EditUserInstrumentVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUserInstrument(string id, int[] genreId, [Bind("Id,InstrumentId,Level")] UserInstrument userInstrument)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(userInstrument);
                    var userInstrumentsList = from u in _context.UserInstrumentGenres
                                              where u.Id == id && u.InstrumentId == userInstrument.InstrumentId
                                              select u;

                    foreach (var item in userInstrumentsList)
                    {
                        _context.UserInstrumentGenres.Remove(item);
                    }
                    foreach (var item in genreId)
                    {
                        var userInstrumentGenre = new UserInstrumentGenre { Id = id, InstrumentId = userInstrument.InstrumentId, GenreId = item };
                        _context.Add(userInstrumentGenre);
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("Profile", new { id = userInstrument.Id });
            }
            return View();
        }

    }
}