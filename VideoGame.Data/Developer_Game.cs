using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGame.Data
{
    public class Developer_Game
    {
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }

        public virtual VideoGame Game { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey(nameof(Developer))]
        public int DeveloperId { get; set; }
        public virtual GameDeveloper Developer { get; set; }
    }
}
