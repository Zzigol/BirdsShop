using BirdsShop.Domain.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BirdsShop.Domain.ViewModels.Bird
{
    public class BirdViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Введите имя")]
        [MinLength(2, ErrorMessage = "Минимальная длина должна быть больше двух символов")]
        public string? Name { get; set; }
        [Display(Name = "Описание")]
        public string? Description { get; set; }
        [Display(Name = "Размер")]
        [Required(ErrorMessage = "Укажите размер")]
        public double? Size { get; set; } // Размер в сантиметрах
        [Display(Name = "Стоимость")]
        [Required(ErrorMessage = "Укажите стоимость")]
        public decimal Price { get; set; }

        public DateTime DataCreate { get; set; }
        [Display(Name = "Вид птицы")]
        [Required(ErrorMessage = "Выберите вид")]
        public string Species { get; set; } //Вид

        public IFormFile Avatar { get; set; }
        public byte[]? Image { get; set; }
    }
}
