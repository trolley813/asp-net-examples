using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace _20200921.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public IdentityUser User { get; set; }
        public Item Item { get; set; }
        public int Score { get; set; }
        public string Text { get; set; }
    }
}
