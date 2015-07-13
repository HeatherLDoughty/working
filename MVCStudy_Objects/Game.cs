using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCStudy_Objects
{
    class Game
    {
        [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       protected Guid mUniqueID;
       public Guid UniqueID { get { return mUniqueID; } }

       CardSet Cards { get; set; }
       int Flips { get; set; }
       int WinTimeSeconds { get; set; }

    }
}
