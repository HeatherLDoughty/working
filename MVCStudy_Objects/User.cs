using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVCStudy_Objects
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        protected Guid mUniqueID;
        public Guid UniqueID { get { return mUniqueID; } }

        public string Name { get; set; }
        public string Password { get; set; }

        protected Game mHighScoreCardGame;
        public Game HighScoreCardGame { get { return mHighScoreCardGame; } }

    }
}
