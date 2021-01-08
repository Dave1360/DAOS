using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicDating.Models.Entities;

namespace MusicDating.Models.ViewModels
{
    public class AddInstrumentVm
    {
        public ApplicationUser ApplicationUser { get; set; }
        public int Level { get; set; }
        public SelectList Instruments { get; set; }
        public int InstrumentId { get; set; }
        public SelectList Genres { get; set; }
        public int GenreId { get; set; }

    }
}