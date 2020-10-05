using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20200921.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
