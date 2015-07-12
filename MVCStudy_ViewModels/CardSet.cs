using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCStudy_ViewModels
{
   public class CardSet : List<Card>
    {
        [Key]
        public Guid UniqueID { get; set; }
        
        public string SetName { get; set; }

        public int TimesPlayed {get; set;}

        public User User { get; set; }

    }
}
