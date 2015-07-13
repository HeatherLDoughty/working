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

       public int WinTimeSeconds { get; set; }

       [DisplayFormat(DataFormatString = "{0:mm:ss}")]
       public DateTime WinTime
       {
           get { return DateTime.Now.Date.AddSeconds(WinTimeSeconds); }
       }

       public int Matches
       {
           get { return Cards.Count(x => x.Matched);}
       }

       [DisplayFormat(DataFormatString="{0}%")]
       public int? Percentage 
       {
           get { return Flips == 0 ? (int?)null : (int)(((double)Matches / (double)Flips) * 100); }
       }

       public int Score
       {
           get { int tally = Percentage.HasValue ? Cards.Count * Percentage.Value - WinTimeSeconds : 0; 
              return tally > 0 ? tally : 1;
           }
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
