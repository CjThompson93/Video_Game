using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGame.Data
{
    public class GameDeveloper
    {
        [Key]
        public int DeveloperId { get; set; }

        [Required]
        public string DeveloperName { get; set; }
    }
}
