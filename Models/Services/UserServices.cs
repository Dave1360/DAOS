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

namespace MusicDating.Models.Services
{
    public class UserServices
    {
        public async static Task<UserInstrumentVm> SearchForUsers(ApplicationDbContext _context, string instrumentName, int genreId)
        {
            var users = from u in _context.UserInstruments.Include(u => u.UserInstrumentGenres).Include(u => u.ApplicationUser).Include(u => u.Instrument)
                        select u;

            var genres = from g in _context.UserInstrumentGenres.Include(g => g.Genre)
                         select g.Genre;

            if (!string.IsNullOrEmpty(instrumentName))
            {
                users = users.Where(u => u.Instrument.Name == instrumentName);
            }

            // if (!string.IsNullOrEmpty(genreId))
            // {
            // Filter some shit here
            // }

            var userInstrumentVM = new UserInstrumentVm
            {
                UserInstruments = await users.Distinct().ToListAsync(),
                Instruments = new SelectList(await _context.Instruments.ToListAsync(), "Name", "Name"),
                Genres = new SelectList(await _context.Genres.ToListAsync(), "GenreName", "GenreName"),
                InstrumentName = instrumentName,
                GenreId = genreId
                // UserInstrumentGenre = await userInstruments.ToListAsync(),
                // Genres = new SelectList(await genreQuery.Distinct().ToListAsync())
            };

            return userInstrumentVM;
        }
    }
}