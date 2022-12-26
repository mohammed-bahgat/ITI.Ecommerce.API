using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Ecommerce.Models;

namespace DTOs
{
    public class ProductDto
    {
        public int ID { get; set; }
        [Display(Name = "Name AraBic")]
        [Required(ErrorMessage = "حثل الاسم مطلوب")]
        [MaxLength(500, ErrorMessage = "لا يزيد عن 500")]
        [MinLength(4, ErrorMessage = "Must Be More Than Or Equals 4 Chars.")]
        public string NameAR { get; set; }
        [Display(Name = "Name English")]
        [Required(ErrorMessage = "حثل الاسم مطلوب")]
        [MaxLength(500, ErrorMessage = "لا يزيد عن 500")]
        [MinLength(4, ErrorMessage = "Must Be More Than Or Equals 4 Chars.")]
        public string NameEN { get; set; }
        [Display(Name = " Brand")]
        [Required(ErrorMessage = "حثل البرند مطلوب")]
        [MaxLength(500, ErrorMessage = "لا يزيد عن 500")]
        public string Brand { get; set; }
        [Display(Name = " Description")]
        [Required(ErrorMessage = "حثل الوصف مطلوب")]
        [MaxLength(500, ErrorMessage = "لا يزيد عن 500")]

        public string Description { get; set; }

        public int CategoryID { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]

        public int Quantity { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public float UnitPrice { get; set; }
        [Range(0, float.MaxValue, ErrorMessage = "Please enter valid  Number")]
        public float Discount { get; set; }
        [Range(0, float.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public float TotalPrice { get; set; }

        public ICollection<ProductImageDto> ProductImageList { get; set; }
     
    }
}

