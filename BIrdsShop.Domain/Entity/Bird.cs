using BirdsShop.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsShop.Domain.Entity
{
    public class Bird
    {
        
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }        

        public double? Size { get; set; } // Размер в сантиметрах

        public decimal Price { get; set; }

        public DateTime DataCreate { get; set; }

        public SpeciesBirds Species { get; set; } //Вид

        public byte[]? Avatar { get; set; }
    }
    
}
