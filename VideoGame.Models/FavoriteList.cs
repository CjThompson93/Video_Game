using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGame.Data;

namespace VideoGame.Models
{
    public class FavoriteList
    {
        public string GameTitle { get; set; }
        public string DeveloperName { get; set; }
        public List<GameRating> Ratings { get; set; }
    }
}
