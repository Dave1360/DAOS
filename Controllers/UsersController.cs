using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public async Task<IActionResult> Index(int instrumentId, int genreId)
        {
            // Do some coding - filter users to only display those who play the instrument
            // Get list of instruments
            UserInstrumentVm userInstrumentVM = await UserServices.SearchForUsers(_context, instrumentId, genreId);

            return View(userInstrumentVM);
        }

        // GET: User/Details/5
        public async Task<IActionResult> Profile(string? id)
        {
          if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            Console.WriteLine(user);

            return View(user);
        }

    }
}
