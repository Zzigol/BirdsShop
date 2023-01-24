using BirdsShop.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsShop.Domain.Entity
{
    public class Bird
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }        

        public float Size { get; set; } // Размер в сантиметрах

        public decimal Price { get; set; }

        public DateTime DataCreate { get; set; }

        public Species Species { get; set; } //Вид


    }
}
