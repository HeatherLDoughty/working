using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCStudy_ViewModels
{
    public class Game
    {
       [Key]
       public Guid UniqueID { get; set; }

       public CardSet Cards { get; set; }

       public int Flips { get; set; }

       public int WinTimeTicks { get; set; }

       public int Matches
       {
           get { return Cards.Count(x => x.Matched);}
       }

       [DisplayFormat(DataFormatString="{0}%")]
       public int? Percentage 
       {
            get{return Matches == 0 ? (int?)null : (int)(Flips / Matches);}
       }

       public int Score
       {
           //TODO: include time calc in score
            get{return Percentage.HasValue ? Cards.Count * Percentage.Value : 0;}
       }

        public string UserName
        {
            get { return User.Name; }
        }

        public string HighScoreCardSet
        {
            get { return HighScoreGame.Cards.SetName; }
        }

        public int HighScore
        {
            get { return HighScoreGame.Score; }
        }

        [ScaffoldColumn(false)]
        public Game HighScoreGame { get; set; }

        [ScaffoldColumn(false)]
        public User User { get; set; }
    }
}
