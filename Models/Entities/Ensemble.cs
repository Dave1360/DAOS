using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicDating.Models.Entities
{
    public class Ensemble
    {
        public int EnsembleId { get; set; }

        public string EnsembleName { get; set; }

        public string coverImg { get; set; }

        public string EnsembleDescription { get; set; }

        // Navigation properties
        public ICollection<GenreEnsemble> GenreEnsembles { get; set; }
    }
}