using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGame.Data;

namespace VideoGame.Models
{
    public class VideoGameList
    {
        public int GameId { get; set; }
      
        public string Title { get; set; }
        public virtual ICollection<GameDeveloperList> Developers { get; set; } = new List<GameDeveloperList>();
        public virtual ICollection<GameRatingList> GameRatings { get; set; } = new List<GameRatingList>();
    }
}
