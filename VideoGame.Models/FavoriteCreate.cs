using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGame.Models
{
    public class FavoriteCreate
    {
        public int GameId { get; set; }
        public Guid UserId { get; set; }
    }
}
