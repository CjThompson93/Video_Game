using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGame.Data
{
    public class Favorite
    {
        [Key]
        public int FavoriteId { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public virtual VideoGame Game { get; set; }
    }
}
