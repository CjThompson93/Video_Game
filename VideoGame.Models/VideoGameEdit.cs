using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGame.Models
{
    public class VideoGameEdit
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public string GameType { get; set; }
        public int GameLength { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
