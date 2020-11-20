using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicDating.Models.Entities;

namespace MusicDating.Models.ViewModels
{
    public class UserInstrumentVm
    {
        public IEnumerable<UserInstrument> UserInstruments { get; set; }
        public SelectList Instruments { get; set; }
        public string InstrumentName { get; set; }
        public SelectList Genres { get; set; }
        public string GenreName { get; set; }

    }
}