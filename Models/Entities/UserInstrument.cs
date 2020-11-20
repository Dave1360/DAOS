using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;

namespace MusicDating.Models.Entities
{
    public class UserInstrument
    {


        public string Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public int InstrumentId { get; set; }
        public Instrument Instrument { get; set; }

        public int Level { get; set; }

        public ICollection<UserInstrumentGenre> UserInstrumentGenres { get; set; }

    }
}