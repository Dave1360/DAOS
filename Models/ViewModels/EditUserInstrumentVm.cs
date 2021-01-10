using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicDating.Models.Entities;

namespace MusicDating.Models.ViewModels
{
    public class EditUserInstrumentVm
    {
        public UserInstrument UserInstrument { get; set; }
        public SelectList Genres { get; set; }
        public int GenreId { get; set; }

    }
}