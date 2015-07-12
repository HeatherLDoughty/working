using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
namespace MVCStudy_ViewModels
{
    public class Card
    {
       [Key]
       public Guid UniqueID { get; set; }

       public Bitmap Image { get; set; }

       public bool Matched { get; set; }

       public Guid SetID { get; set; }
    }
}
