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
/// <Refernces>
/// Link:
/// Link:
/// Link:
/// Link:
/// </Refernces>
    public class FoodAppWorker
    {
        ArrayList recipeArray = new ArrayList();
        recipe newRecipe = new recipe();
        double scale;

//----------------------------------------------------------------------------------------->
        //allows the use to input the details of the recipe aswell as amount of ingredients and steps
        public void recipeInputDetails(recipe newRecipe)
        {
            try 
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
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input");
                Menu();
            }
            recipeArray.Add(newRecipe);
            Menu();
        }
//----------------------------------------------------------------------------------------->
        //prints the recipe details
        public void recipePrint(recipe newRecipe)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-----------------------------------");
            Console.ResetColor();
            Console.WriteLine($"{newRecipe.name}" + " recipe:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ingredients: ");
            Console.ResetColor();
            foreach (ingredient ingredient in newRecipe.ingredient)
            {
                Console.WriteLine($"{ingredient.name}" + " - " + $"{ingredient.quantity}" + " " + $"{ingredient.measurement}");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Steps: ");
            Console.ResetColor();
            int i = 1;
            foreach (String step in newRecipe.step)
            {
                Console.WriteLine("Step " + i + ": " + $"{step}");
                i++;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-----------------------------------");
            Console.ResetColor();
            Menu();
        }
//----------------------------------------------------------------------------------------->
        //scales the recipe ingredients by a user inputted amount
        public void recipeScale(recipe newRecipe)
        {
            try
            {
                Console.WriteLine("Enter the amount you'd like to scale your recipe by: ");
                scale = Convert.ToDouble(Console.ReadLine());
                foreach (ingredient ingredient in newRecipe.ingredient)
                {
                    ingredient.quantity = (Convert.ToInt32(ingredient.quantity) * scale).ToString();
                }
                Menu();
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input please enter a number");
                Menu();
            }
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
        //resets the recipe to the original details - asks the user to confirm
        public void resetRecipe(recipe newRecipe)
        {
            Console.WriteLine("Are you sure you would like to reset your recipe?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");

            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                newRecipe.name = null;
                newRecipe.ingredient.Clear();
                newRecipe.step.Clear();
                Console.WriteLine("Recipe reset");
            }
            else if (choice == 2)
            {
                Console.WriteLine("Recipe not reset");
            }
            Menu();
        }
//----------------------------------------------------------------------------------------->
        //menu for the user to choose what they want to do
        public void Menu()
        {
            try
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
                        Console.WriteLine("Invalid choice please enter a number from 1-6");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input please enter a number");
                Menu();
            }
        }
//----------------------------------------------------------------------------------------->
    }
}
