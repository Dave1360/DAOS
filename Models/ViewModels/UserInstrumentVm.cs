using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicDating.Models.Entities;

namespace MusicDating.Models.ViewModels
{
    public class UserInstrumentVm
    {
        public List<UserInstrument> UserInstrument { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public SelectList Instruments { get; set; }
        public string InstrumentName { get; set; }

    }
}