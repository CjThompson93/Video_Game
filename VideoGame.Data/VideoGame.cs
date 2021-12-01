using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGame.Data
{
    public class VideoGame
    {
        [Key]
        public int GameId { get; set; }

        [Required]
        public string Title { get; set; }

        public string GameType { get; set; }

        public int GameLength { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual ICollection<Developer_Game> Developers { get; set; } = new List<Developer_Game>();
        public virtual ICollection<Rating_Game> GameRatings { get; set; } = new List<Rating_Game>();
    }
}
