using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCStudy_ViewModels
{
    public class ViewModel_Game
    {
       [Key]
       public Guid UniqueID { get; set; }

       public ViewModel_CardSet Cards { get; set; }

       public int Flips { get; set; }

       public int WinTimeSeconds { get; set; }

       [DisplayFormat(DataFormatString = "{0:mm:ss}")]
       public DateTime WinTime
       {
           get { return DateTime.Now.Date.AddSeconds(WinTimeSeconds); }
       }

       [DisplayFormat(DataFormatString="{0}%")]
       public int? Percentage 
       {
           get { return Flips == 0 ? (int?)null : (int)(((double)Cards.Count / (double)Flips) * 100); }
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

        [ScaffoldColumn(false)]
        public ViewModel_User User { get; set; }
    }
}
