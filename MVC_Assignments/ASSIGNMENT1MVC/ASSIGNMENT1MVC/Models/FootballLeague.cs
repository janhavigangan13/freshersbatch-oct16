using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASSIGNMENT1MVC.Models
{
    [Table("FootBallLeague")]
    public class FootballLeague
    {
        public int MatchID { get; set; }
        [Required]
        public string TeamName1 { get; set; }
        [Required]
        public string TeamName2 { get; set; }
        public string Status1 { get; set; }
        public string WinningTeam { get; set; }
        public int Points { get; set; }
    }
}