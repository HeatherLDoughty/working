using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace MVCStudy_ViewModels
{
    public class User
    {
        [Key]
        public Guid UniqueID { get; set; }

        [MaxLength(50, ErrorMessage = "Name can not be longer than 50 characters")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessage = "Password can not be longer than 50 characters")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

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

    }
}
