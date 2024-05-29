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
                    ingredient.quantity = (Convert.ToInt32(ingredient.quantity) * scale).ToString();
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
                ingredient.quantity = (Convert.ToInt32(ingredient.quantity) / scale).ToString();
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
