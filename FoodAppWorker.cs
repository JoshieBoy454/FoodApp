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
        recipe newRecipe = new recipe();

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
            public String name { get; set; }
            public ArrayList step { get; set; }
            public ArrayList ingredient { get; set; }
            public recipe()
            {
                step = new ArrayList();
                ingredient = new ArrayList();
            }
        }
        
        
        
        public void recipeInputDetails(recipe newRecipe)
        {
            

            Console.WriteLine("Enter the name of the recipe: ");
            newRecipe.name = Console.ReadLine();

            Console.WriteLine("Enter the number of ingredients: ");
            int ingredientNo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the number of steps: ");
            int stepNo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the ingredients: ");
            for (int i = 0; i < ingredientNo; i++)
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
            for (int i = 0; i < stepNo; i++)
            {
                Console.WriteLine("Enter step " + (i + 1) + ": ");
                newRecipe.step.Add(Console.ReadLine());
            }
            recipeArray.Add(newRecipe);
        }

        public void recipePrint(recipe newRecipe)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"{newRecipe.name}" + " recipe:");
            Console.WriteLine("Ingredients: ");
            foreach (ingredient ingredient in newRecipe.ingredient)
            {
                Console.WriteLine($"{ingredient.name}" + " - " + $"{ingredient.quantity}" + " " + $"{ingredient.measurement}");
            }
            Console.WriteLine("Steps: ");
            int i = 1;
            foreach (String step in newRecipe.step)
            {
                Console.WriteLine("Step " + i + ": " + $"{step}");
                i++;
            }
            Console.WriteLine("-----------------------------------");

        }
        //public void Menu()
        //{          Console.WriteLine("1. Add a recipe");
        //           Console.WriteLine("2. Print a recipe");
        //           Console.WriteLine("3. Exit");
        //           Console.WriteLine("Enter your choice: ");
        //           int choice = Convert.ToInt32(Console.ReadLine());
        //           switch (choice)
        //    {
        //        case 1:
        //            recipeInputDetails();
        //            break;
        //        case 2:
        //            recipePrint();
        //            break;
        //        case 3:
        //            Environment.Exit(0);
        //            break;
        //        default:
        //            Console.WriteLine("Invalid choice");
        //            break;
        //    }
        //}
    }
}
