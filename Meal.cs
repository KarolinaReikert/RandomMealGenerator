using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomMealGenerator
{
    public class Meal
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string[] Recipe { get; set; }
        public string Country { get; set; }
        public int Id { get; set; }
    }
}
