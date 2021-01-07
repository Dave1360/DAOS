using System.ComponentModel.DataAnnotations;

namespace MusicDating.Models.Entities {
    public class Agent {
        public int AgentId { get; set; }
        
        
        [RegularExpression(@"^([1-9]|10)$", ErrorMessage="Level must be between 1 and 10")]
        [Required]
        public int Level { get; set; }


        // Navigation properties
        public int InstrumentId { get; set; }
        public Instrument Instrument { get; set; }
    }
}