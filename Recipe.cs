using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp
{
    //recipe class contains the steps and ingredients of the recipe (ingredient object stored as an attribute of recipe object)
    public class recipe
    {
        //uses an arraylist to have multiple steps and ingredients
        public String name { get; set; }
        public ArrayList step { get; set; }
        public ArrayList ingredient { get; set; }
        public recipe()
        {
            step = new ArrayList();
            ingredient = new ArrayList();
        }
    }
}
