using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVCStudy_Objects
{
   public class Card
    {

       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       protected Guid mUniqueID;
       public Guid UniqueID { get { return mUniqueID; } }

       public byte[] image {get; set;}

    }
}
