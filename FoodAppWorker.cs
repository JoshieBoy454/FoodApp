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
        ArrayList recipeArray = new ArrayList();

        //ingredient class contains the name, quantity and measurement of the ingredient
        public class ingredient
        {
            public String name { get; set; }
            public String quantity { get; set; }
            public String measurement { get; set; }
        }
        //recipe class contains the steps and ingredients of the recipe (ingredient object as an attribute of recpe onject)
        public class recipe
        {
            //uses a list to have multiple steps and ingredients
            public List<String> step { get; set; }
            public List<ingredient> ingredient { get; set; }
            public recipe()
            {
                step = new List<String>();
                ingredient = new List<ingredient>();
            }
        }
        
        
        
        public void recipeInputDetails()
        {
            recipe newRecipe = new recipe();

            Console.WriteLine("Enter the name of the recipe: ");
            String recipeName = Console.ReadLine();

            Console.WriteLine("Enter the number of ingredients: ");
            int numIngredients = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the number of steps: ");
            int numSteps = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the ingredients: ");
            for (int i = 0; i < numIngredients; i++)
            {
                ingredient newIngredient = new ingredient();

                Console.WriteLine("Enter the name of the ingredient: ");
                newIngredient.name = Console.ReadLine();

                Console.WriteLine("Enter the quantity of the ingredient: ");
                newIngredient.quantity = Console.ReadLine();

                Console.WriteLine("Enter the measurement of the ingredient: ");
                newIngredient.measurement = Console.ReadLine();
                //adds an object of the ingredient class to the end of the ingredient list of the recipe object
                newRecipe.ingredient.Add(newIngredient);
            }
            Console.WriteLine("Enter the steps: ");
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine("Enter step " + (i + 1) + ": ");
                newRecipe.step.Add(Console.ReadLine());
            }
            recipeArray.Add(newRecipe);
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
