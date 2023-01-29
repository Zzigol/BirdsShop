using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsShop.Domain.Enum
{
    public enum SpeciesBirds
    {
        [Display(Name = "Мелкие виды")]
        Small=0,
        [Display(Name = "Средние виды")]
        Medium =1,
        [Display(Name = "Крупные виды")]
        Large =2
    }
}
