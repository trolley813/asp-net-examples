using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _20200921.Models
{
    public class Item
    {
        [Display(Name = "ID")]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Display(Name = "Reviews")]
        public List<Review> Reviews { get; set; }
    }
}
