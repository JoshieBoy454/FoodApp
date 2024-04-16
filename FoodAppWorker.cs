using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp
{/// <summary>
/// Joshua Gain 
/// ST10369044
/// PROG6221
/// </summary>
    public class FoodAppWorker
    {
        ArrayList recipeArray = new ArrayList();
        recipe newRecipe = new recipe();
        int scale;

//----------------------------------------------------------------------------------------->
        //ingredient class contains the name, quantity and measurement of the ingredient
        public class ingredient
        {
            public String name { get; set; }
            public String quantity { get; set; }
            public String measurement { get; set; }
        }
//----------------------------------------------------------------------------------------->
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
//----------------------------------------------------------------------------------------->
        //allows the use to input the details of the recipe aswell as amount of ingredients and steps
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
            Menu();
        }
//----------------------------------------------------------------------------------------->
        //prints the recipe details
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
            Menu();
        }
//----------------------------------------------------------------------------------------->
        //scales the recipe ingredients by a user inputted amount
        public void recipeScale(recipe newRecipe)
        {
            Console.WriteLine("Enter the amount you'd like to scale your recipe by: ");
            scale = Convert.ToInt32(Console.ReadLine());
            foreach (ingredient ingredient in newRecipe.ingredient)
            {
                ingredient.quantity = (Convert.ToInt32(ingredient.quantity) * scale).ToString();
            }
            Menu();
        }
//----------------------------------------------------------------------------------------->
        //resets the recipe scale to the original amount
        public void resetScale(recipe newRecipe)
        {
            foreach (ingredient ingredient in newRecipe.ingredient)
            {
                ingredient.quantity = (Convert.ToInt32(ingredient.quantity) / scale).ToString();
            }
            Menu();
        }
//----------------------------------------------------------------------------------------->
        //resets the recipe to the original details
        public void resetRecipe(recipe newRecipe)
        {
            foreach(recipe r in recipeArray)
            {
                r.name = null;
                r.ingredient.Clear();
                r.step.Clear();
            }
            Console.WriteLine("Recipe reset");
            Menu();
        }
//----------------------------------------------------------------------------------------->
        //menu for the user to choose what they want to do
        public void Menu()
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("1. Add a recipe");
            Console.WriteLine("2. Print a recipe");
            Console.WriteLine("3. Scale recipe ingredients");
            Console.WriteLine("4. Reset recipe scale");
            Console.WriteLine("5. Reset recipe");
            Console.WriteLine("6. Exit");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    recipeInputDetails(newRecipe);
                    break;
                case 2:
                    recipePrint(newRecipe);
                    break;
                case 3:
                    recipeScale(newRecipe);
                    break;
                case 4:
                    resetScale(newRecipe);
                    break;
                case 5:
                    resetRecipe(newRecipe);
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
//----------------------------------------------------------------------------------------->
    }
}
