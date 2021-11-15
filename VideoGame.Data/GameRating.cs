using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGame.Data
{
    public class GameRating
    {
        [Key]
        public int RatingId { get; set; }
        public string RatingName { get; set; }
    }
}
