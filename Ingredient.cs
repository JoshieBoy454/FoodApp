using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp
{
    //ingredient class contains the name, quantity and measurement of the ingredient
    public class ingredient
    {
        public String name { get; set; }
        public double quantity { get; set; }
        public String measurement { get; set; }
        public String foodGroup { get; set; }
        public double calories { get; set; }
    }
}
//---------------------------------------END-OF-FILE--------------------------------------->