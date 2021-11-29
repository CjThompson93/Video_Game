using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGame.Data;

namespace VideoGame.Models
{
    public class VideoGameDetails
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public string GameType { get; set; }
        public int GameLength { get; set; }
        public DateTime DateCreated { get; set; }
        public List<GameDeveloper> DeveloperName { get; set; }
        public List<GameRating> GameRatings { get; set; }
    }
}
