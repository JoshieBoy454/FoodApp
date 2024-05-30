﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FoodApp
{/// <summary>
/// Joshua Gain 
/// ST10369044
/// PROG6221
/// </summary>
/// <Refernces>
/// Link:https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/creating-and-throwing-exceptions
/// Link:https://chatgpt.com/share/1aa67528-c4bc-4bbe-a49c-e9df633a8c63
/// Link:https://www.youtube.com/watch?v=QqWfw_CFR6Q
/// Link:https://www.youtube.com/results?search_query=delegates+in+c%23
/// Link:https://www.youtube.com/results?search_query=lambda+expression+c%23
/// Link:https://www.youtube.com/results?search_query=generic+collections+in+c%23+
/// Link:
/// Link:
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
        // Assisted by ChatGPT
        // Link: https://chatgpt.com/share/1aa67528-c4bc-4bbe-a49c-e9df633a8c63
        Dictionary<(string from, string to), double> conversionFactors = new Dictionary<(string from, string to), double>
        {
            {("teaspoon","tablespon"), 1.0/3},
            {("tsp","tbsp"), 1.0/3},
            {("tablespoon","teaspoon"), 3},
            {("tbsp", "tsp"), 3},
            {("teaspoon", "cup"), 1.0 / 48},
            {("tsp", "cup"), 1.0 / 48},
            {("tablespoon", "cup"), 1.0 / 16},
            {("tbsp", "cup"), 1.0 / 16},
            {("cup", "teaspoon"), 48},
            {("cup", "tsp"), 48},
            {("cup", "tablespoon"), 16},
            {("cup", "tbsp"), 16},
            {("cup", "ounce"), 8},
            {("cup", "oz"), 8},
            {("ounce", "cup"), 1.0 / 8},
            {("oz", "cup"), 1.0 / 8},
            {("ounce", "pound"), 1.0 / 16},
            {("oz", "lb"), 1.0 / 16},
            {("pound", "ounce"), 16},
            {("lb", "oz"), 16},
            {("ounce", "gram"), 28.3495},
            {("oz", "g"), 28.3495},
            {("gram", "ounce"), 1.0 / 28.3495},
            {("g", "oz"), 1.0 / 28.3495},
            {("pound", "kilogram"), 1.0 / 2.20462},
            {("lb", "kg"), 1.0 / 2.20462},
            {("kilogram", "pound"), 2.20462},
            {("kg", "lb"), 2.20462},
            {("liter", "milliliter"), 1000},
            {("l", "ml"), 1000},
            {("L", "ml"), 1000},
            {("milliliter", "liter"), 1.0 / 1000},
            {("ml", "l"), 1.0 / 1000},
            {("ml", "L"), 1.0 / 1000},
            {("liter", "cup"), 4.22675},
            {("l", "cup"), 4.22675},
            {("L", "cup"), 4.22675},
            {("cup", "liter"), 1.0 / 4.22675},
            {("cup", "l"), 1.0 / 4.22675},
            {("cup", "L"), 1.0 / 4.22675},
            {("quart", "cup"), 4},
            {("qt", "cup"), 4},
            {("cup", "quart"), 1.0 / 4},
            {("cup", "qt"), 1.0 / 4},
            {("gallon", "quart"), 4},
            {("gal", "qt"), 4},
            {("quart", "gallon"), 1.0 / 4},
            {("qt", "gal"), 1.0 / 4},
            {("gallon", "cup"), 16},
            {("gal", "cup"), 16},
            {("cup", "gallon"), 1.0 / 16},
            {("cup", "gal"), 1.0 / 16},
        };

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
                newIngredient.quantity = Convert.ToDouble(Console.ReadLine());

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
            catch(FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input please enter a number.");
                Console.ResetColor();
                recipeInputDetails(newRecipe);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input please try again.");
                Console.ResetColor();
                recipeInputDetails(newRecipe);
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
            recipePrint(newRecipe);
        }
//----------------------------------------------------------------------------------------->
        //scales the recipe ingredients by a user inputted amount
        public void recipeScale(recipe newRecipe)
        {
            try
            {
                Console.WriteLine("Enter the amount you'd like to scale your recipe by: ");
                scale = Convert.ToDouble(Console.ReadLine());
                //checks if the scale is less than zero or zero (throw)
                if(scale < 0)
                {
                    throw new ArgumentOutOfRangeException("scale","Number cannot be less than zero.");
                }
                if (scale == 0)
                {
                    throw new ArgumentException("scale", "Number cannot be zero.");
                }
                
                foreach (ingredient ingredient in newRecipe.ingredient)
                {
                    ingredient.quantity = ingredient.quantity * scale;
                }
                Menu();
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input please enter a number.");
                Console.ResetColor();
                recipeScale(newRecipe);
            }
            catch(ArgumentOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Number cannot be less than zero please enter a non-negative number.");
                Console.ResetColor();
                recipeScale(newRecipe);
            }
            catch(ArgumentException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Number cannot be zero please enter a non-zero number.");
                Console.ResetColor();
                recipeScale(newRecipe);
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input please enter a number.");
                Console.ResetColor();
                recipeScale(newRecipe);
            }
        }
//----------------------------------------------------------------------------------------->
        //resets the recipe scale to the original amount
        public void resetScale(recipe newRecipe)
        {
            foreach (ingredient ingredient in newRecipe.ingredient)
            {
                ingredient.quantity = ingredient.quantity / scale;
            }
            Menu();
        }
//----------------------------------------------------------------------------------------->
        //resets the recipe to the original details - asks the user to confirm
        public void resetRecipe(recipe newRecipe)
        {
            try
            {
                Console.WriteLine("Are you sure you would like to reset your recipe?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (scale < 0)
                {
                    throw new ArgumentOutOfRangeException("choice", "Number cannot be less than zero.");
                }
                if (scale == 0)
                {
                    throw new ArgumentException("choice", "Number cannot be zero.");
                }

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
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input please enter a number");
                Console.ResetColor();
                resetRecipe(newRecipe);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Number cannot be less than zero please enter a non-negative number.");
                Console.ResetColor();
                resetRecipe(newRecipe);
            }
            catch (ArgumentException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Number cannot be zero please enter a non-zero number.");
                Console.ResetColor();
                resetRecipe(newRecipe);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input please try again.");
                Console.ResetColor();
                resetRecipe(newRecipe);
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option please enter a number from 1-6");
                        Console.ResetColor();
                        Menu();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input please enter a number");
                Console.ResetColor();
                Menu();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input please try again.");
                Console.ResetColor();
                Menu();
            }
        }
        //----------------------------------------------------------------------------------------->
    }
}
