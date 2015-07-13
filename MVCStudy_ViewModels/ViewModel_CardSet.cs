using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCStudy_ViewModels
{
   public class ViewModel_CardSet : List<ViewModel_Card>
    {
        [Key]
        public Guid UniqueID { get; set; }
        
        public string Name { get; set; }

        public int TimesPlayed {get; set;}

        public ViewModel_User User { get; set; }

        public string HighScoreCardSet
        {
            get { return HighScoreGame.Cards.Name; }
        }

        public int HighScore
        {
            get { return HighScoreGame.Score; }
        }

        [ScaffoldColumn(false)]
        public ViewModel_Game HighScoreGame { get; set; }

    }
}
