using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp
{
    public class FoodAppWorker
    {
        ArrayList ingredientArray = new ArrayList();
        ArrayList stepArray = new ArrayList();

        public String step { get; set; }
        public class ingredient
        {
            public String name { get; set; }
            public String quantity { get; set; }
            public String measurement { get; set; }
        }

        public void recipeInputDetails()
        {
            Console.WriteLine("How many ingredients does the recipe have.");
            int ingredientNo = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < ingredientNo; i++)
            {
                Console.WriteLine("Enter the ingredient: ");
                ingredientArray.Add(Console.ReadLine());
            }

            Console.WriteLine("How many steps does the recipe have.");
            int stepNo = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < stepNo; i++)
            {
                Console.WriteLine("Enter the step: ");
                stepArray.Add(Console.ReadLine());
            }

        }

        public void recipePrint()
        {
            Console.WriteLine("Ingredients: ");
            foreach (String ingredient in ingredientArray)
            {
                Console.WriteLine(ingredient);
            }

            Console.WriteLine("Steps: ");
            foreach (String step in stepArray)
            {
                Console.WriteLine(step);
            }
        }
    }
}
