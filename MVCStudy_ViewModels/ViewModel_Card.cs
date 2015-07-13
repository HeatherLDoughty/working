using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
namespace MVCStudy_ViewModels
{
    public class ViewModel_Card
    {
       [Key]
       public Guid UniqueID { get; set; }

       public Bitmap Image { get; set; }

    }
}
