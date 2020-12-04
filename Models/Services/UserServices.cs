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
        public async static Task<UserInstrumentVm> SearchForUsers(ApplicationDbContext _context, int instrumentId, int genreId)
        {

            var genres = from g in _context.UserInstrumentGenres.Include(g => g.Genre)
                         select g.Genre;

            var users = from u in _context.ApplicationUsers
            .Include(u=>u.UserInstruments).ThenInclude(u=>u.UserInstrumentGenres).ThenInclude(u=>u.Genre)
            .Include(u=>u.UserInstruments).ThenInclude(u=>u.Instrument)
                        select u;

            if(instrumentId != 0){
                users = from u in users
                from ui in u.UserInstruments
                where ui.Instrument.InstrumentId == instrumentId
                select u;
            }

            if(genreId != 0){
                users = from u in users
                from ui in u.UserInstruments
                from uig in ui.UserInstrumentGenres
                where uig.GenreId == genreId
                select u;
            }


            var userInstrumentVM = new UserInstrumentVm
            {
                ApplicationUsers = await users.ToListAsync(),
                Instruments = new SelectList(await _context.Instruments.ToListAsync(), "InstrumentId", "Name"),
                Genres = new SelectList(await genres.Distinct().ToListAsync(), "GenreId", "GenreName"),
                InstrumentId = instrumentId,
                GenreId = genreId
            };

            return userInstrumentVM;
        }
    }
}