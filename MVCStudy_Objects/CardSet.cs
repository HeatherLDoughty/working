using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVCStudy_Objects
{
    public class CardSet : List<Card>
    {
       [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        protected Guid mUniqueID;
        public Guid UniqueID { get { return mUniqueID; } }

        public string Name { get; set; }

        protected int mTimesplayed;
        public int TimesPlayed { get { return mTimesplayed; } }

        protected User mUser;
        public User User { get { return mUser; } }

        protected Game mHighScoreGame;
        public Game HighScoreGame {get{return mHighScoreGame;}}
        
    }
}
