using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicDating.Models.Entities
{
    public class Genre
    {
        public int GenreId { get; set; }

        public string GenreName { get; set; }


        // Navigation properties
        public ICollection<GenreEnsemble> GenreEnsembles { get; set; }

        public ICollection<UserInstrumentGenre> UserInstrumentGenres { get; set; }
    }
}