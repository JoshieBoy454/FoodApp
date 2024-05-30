using System;
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
/// Link:https://www.geeksforgeeks.org/collections-in-c-sharp/
/// Link:https://stackoverflow.com/questions/6965337/sort-a-list-alphabetically
/// Link:
/// Link:
/// Link:
/// Link:
/// </Refernces>
    public class FoodAppWorker
    {
        ArrayList recipeArray = new ArrayList();
        double scale;
        List<recipe> recipeList = new List<recipe>();
        // defined a delegate for the notifications
        public delegate void CalorieNotificationDelegaet(recipe recipeName);
        public event CalorieNotificationDelegaet CalorieExceeded;
        // Coded with help by ChatGPT
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
        public void recipeInputDetails()
        {
            recipe newRecipe = new recipe();
            //subscribes to the event to notify the user if the calories exceed 300
            CalorieExceeded += NotifyCalorieExceeded;

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

                Console.WriteLine("Enter the food group of the ingredient");
                newIngredient.foodGroup = Console.ReadLine();

                Console.WriteLine("Enter the calories of the ingredient");
                newIngredient.calories = Convert.ToDouble(Console.ReadLine());
                // calculates the total calories of the recipe
                calorieCalculation(newRecipe, newIngredient);

                //adds an object of the ingredient class to the end of the ingredient list of the recipe object
                newRecipe.ingredient.Add(newIngredient);
            }

                Console.WriteLine("Enter the steps: ");
            for (int i = 0; i < stepNo; i++)
            {
                Console.WriteLine("Enter step " + (i + 1) + ": ");
                newRecipe.step.Add(Console.ReadLine());
            }
                recipeList.Add(newRecipe);
            }
            catch(FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input please enter a number.");
                Console.ResetColor();
                recipeInputDetails();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input please try again.");
                Console.ResetColor();
                recipeInputDetails();
            }
            recipeArray.Add(newRecipe);
            Menu();
        }
//----------------------------------------------------------------------------------------->
        //prints the recipe details
        public void recipePrint()
        {
            try
            {
                Console.WriteLine("Please select the recipe you'd like to print");
                Console.WriteLine("1. Manual search.");
                recipeList.Sort();
                for (int x = 0; x < recipeList.Count; x++)
                {
                    Console.WriteLine(x + 2 + ". " + recipeList[x].name);
                }
                int recipeChoice = Convert.ToInt32(Console.ReadLine());
                // uniChoice is used as a Universal Choice for the conversion method
                recipe uniChoice = recipeList[recipeChoice - 2];
                if (recipeChoice == 1)
                {
                    Console.WriteLine("Enter the name of the recipe you would like to print: ");
                    string recipeName = Console.ReadLine();
                    recipe newRecipe = recipeList.Find(recipe => recipe.name == recipeName);
                    Console.ForegroundColor = ConsoleColor.Green;
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
                    Console.WriteLine("Total Calories: " + newRecipe.totalCalories);
                    calInfo(uniChoice);
                    Console.WriteLine("-----------------------------------");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine($"{recipeList[recipeChoice - 2].name}" + " recipe:");
                    Console.WriteLine("Ingredients: ");
                    foreach (ingredient ingredient in recipeList[recipeChoice - 2].ingredient)
                    {
                        Console.WriteLine($"{ingredient.name}" + " - " + $"{ingredient.quantity}" + " " + $"{ingredient.measurement}");
                    }
                    Console.WriteLine("Steps: ");
                    int i = 1;
                    foreach (String step in recipeList[recipeChoice - 2].step)
                    {
                        Console.WriteLine("Step " + i + ": " + $"{step}");
                        i++;
                    }
                    Console.WriteLine("Total Calories: " + recipeList[recipeChoice - 2].totalCalories);
                    calInfo(uniChoice);
                    Console.WriteLine("-----------------------------------");
                    Console.ResetColor();
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input please enter a number.");
                Console.ResetColor();
                recipePrint();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input please try again.");
                Console.ResetColor();
                recipePrint();
            }
            
            Menu();
        }
//----------------------------------------------------------------------------------------->
        //scales the recipe ingredients by a user inputted amount
        public void recipeScale()
        {
            try
            {
                Console.WriteLine("Please select the recipe you'd like to scale");
                Console.WriteLine("1. Manual search.");
                recipeList.Sort();
                for (int x = 0; x < recipeList.Count; x++)
                {
                    Console.WriteLine(x + 2 + ". " + recipeList[x].name);
                }
                int recipeChoice = Convert.ToInt32(Console.ReadLine());
                // uniChoice is used as a Universal Choice for the conversion method
                recipe uniChoice = recipeList[recipeChoice - 2];
                if (recipeChoice == 1)
                {
                    Console.WriteLine("Enter the name of the recipe you would like to scale: ");
                    string recipeName = Console.ReadLine();
                    recipe newRecipe = recipeList.Find(recipe => recipe.name == recipeName); 
                    Console.WriteLine("Enter the amount you'd like to scale your recipe by: ");
                    scale = Convert.ToDouble(Console.ReadLine());
                    //checks if the scale is less than zero or zero (throw)
                    if (scale < 0)
                    {
                        throw new ArgumentOutOfRangeException("scale", "Number cannot be less than zero.");
                    }
                    if (scale == 0)
                    {
                        throw new ArgumentException("scale", "Number cannot be zero.");
                    }

                    foreach (ingredient ingredient in newRecipe.ingredient)
                    {
                        ingredient.quantity = ingredient.quantity * scale;
                        conversionLogic(uniChoice);
                    }
                    newRecipe.totalCalories = newRecipe.totalCalories * scale;
                }
                else
                {
                    Console.WriteLine("Enter the amount you'd like to scale your recipe by: ");
                    scale = Convert.ToDouble(Console.ReadLine());
                    //checks if the scale is less than zero or zero (throw)
                    if (scale < 0)
                    {
                        throw new ArgumentOutOfRangeException("scale", "Number cannot be less than zero.");
                    }
                    if (scale == 0)
                    {
                        throw new ArgumentException("scale", "Number cannot be zero.");
                    }

                    foreach (ingredient ingredient in recipeList[recipeChoice - 2].ingredient)
                    {
                        ingredient.quantity = ingredient.quantity * scale;
                        conversionLogic(uniChoice) ;
                    }
                    recipeList[recipeChoice - 2].totalCalories = recipeList[recipeChoice - 2].totalCalories * scale;
                }
                Menu();
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input please enter a number.");
                Console.ResetColor();
                recipeScale();
            }
            catch(ArgumentOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Number cannot be less than zero please enter a non-negative number.");
                Console.ResetColor();
                recipeScale();
            }
            catch(ArgumentException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Number cannot be zero please enter a non-zero number.");
                Console.ResetColor();
                recipeScale();
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input please enter a number.");
                Console.ResetColor();
                recipeScale();
            }
        }
//----------------------------------------------------------------------------------------->
        //resets the recipe scale to the original amount
        public void resetScale()
        {
            Console.WriteLine("Please select the recipe whose scale you'd like to reset.");
            Console.WriteLine("1. Manual search.");
            recipeList.Sort();
            for (int x = 0; x < recipeList.Count; x++)
            {
                Console.WriteLine(x + 2 + ". " + recipeList[x].name);
            }
            int recipeChoice = Convert.ToInt32(Console.ReadLine());
            if (recipeChoice == 1)
            {
                Console.WriteLine("Enter the name of the recipe whose scale you'd like to reset: ");
                string recipeName = Console.ReadLine();
                recipe newRecipe = recipeList.Find(recipe => recipe.name == recipeName);
                foreach (ingredient ingredient in newRecipe.ingredient)
                {
                    ingredient.quantity = ingredient.quantity / scale;
                }
                newRecipe.totalCalories = newRecipe.totalCalories / scale;
            }
            else
            {
                foreach (ingredient ingredient in recipeList[recipeChoice - 2].ingredient)
                {
                    ingredient.quantity = ingredient.quantity / scale;
                }
                recipeList[recipeChoice - 2].totalCalories = recipeList[recipeChoice - 2].totalCalories / scale;
            }
            Menu();
        }
//----------------------------------------------------------------------------------------->
        //resets the recipe to the original details - asks the user to confirm
        public void resetRecipe()
        {
            try
            {
                Console.WriteLine("Please select the recipe you'd like to scale");
                Console.WriteLine("1. Manual search.");
                recipeList.Sort();
                for (int x = 0; x < recipeList.Count; x++)
                {
                    Console.WriteLine(x + 2 + ". " + recipeList[x].name);
                }
                int recipeChoice = Convert.ToInt32(Console.ReadLine());
                // uniChoice is used as a Universal Choice for the conversion method
                recipe uniChoice = recipeList[recipeChoice - 2];
                if (recipeChoice == 1)
                {
                    Console.WriteLine("Enter the name of the recipe you would like to scale: ");
                    string recipeName = Console.ReadLine();
                    recipe newRecipe = recipeList.Find(recipe => recipe.name == recipeName);
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
                        newRecipe.totalCalories = 0;
                        Console.WriteLine("Recipe reset");
                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("Recipe not reset");
                    }
                }
                else
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
                        recipeList[recipeChoice - 2].name = null;
                        recipeList[recipeChoice - 2].ingredient.Clear();
                        recipeList[recipeChoice - 2].step.Clear();
                        recipeList[recipeChoice - 2].totalCalories = 0;
                        Console.WriteLine("Recipe reset");
                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("Recipe not reset");
                    }
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input please enter a number");
                Console.ResetColor();
                resetRecipe();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Number cannot be less than zero please enter a non-negative number.");
                Console.ResetColor();
                resetRecipe();
            }
            catch (ArgumentException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Number cannot be zero please enter a non-zero number.");
                Console.ResetColor();
                resetRecipe();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input please try again.");
                Console.ResetColor();
                resetRecipe();
            }

            Menu();
        }
//----------------------------------------------------------------------------------------->
        //converts the measurement of the ingredients
        public double ConvertMeasurement(double quantity, string from, string to)
        {
            if (conversionFactors.TryGetValue((from, to), out double factor))
            {
                return quantity * factor;
            }
            // No conversion if not found
            return quantity; 
        }
//----------------------------------------------------------------------------------------->
        // conversion logic that implements the dictionary conversions by itterating through else ifs
        // Coded with the help of ChatGPT
        // Link: https://chatgpt.com/share/1aa67528-c4bc-4bbe-a49c-e9df633a8c63
        public void conversionLogic(recipe uniChoice)
        {
            foreach (ingredient ingredient in uniChoice.ingredient)
            {
                // Teaspoon and Tablespoon
                if (ingredient.measurement == "teaspoon" && ingredient.quantity >= 3)
                {
                    ingredient.quantity = ConvertMeasurement(ingredient.quantity, "teaspoon", "tablespoon");
                    ingredient.measurement = "tablespoon";
                }
                else if (ingredient.measurement == "tablespoon" && ingredient.quantity >= 1)
                {
                    ingredient.quantity = ConvertMeasurement(ingredient.quantity, "tablespoon", "teaspoon");
                    ingredient.measurement = "teaspoon";
                }

                // Teaspoon and Cup 
                else if (ingredient.measurement == "teaspoon" && ingredient.quantity >= 48)
                {
                    ingredient.quantity = ConvertMeasurement(ingredient.quantity, "teaspoon", "cup");
                    ingredient.measurement = "cup";
                }
                else if (ingredient.measurement == "cup" && ingredient.quantity >= 1)
                {
                    ingredient.quantity = ConvertMeasurement(ingredient.quantity, "cup", "teaspoon");
                    ingredient.measurement = "teaspoon";
                }

                // Tablespoon and Cup
                else if (ingredient.measurement == "tablespoon" && ingredient.quantity >= 16)
                {
                    ingredient.quantity = ConvertMeasurement(ingredient.quantity, "tablespoon", "cup");
                    ingredient.measurement = "cup";
                }
                else if (ingredient.measurement == "cup" && ingredient.quantity >= 1)
                {
                    ingredient.quantity = ConvertMeasurement(ingredient.quantity, "cup", "tablespoon");
                    ingredient.measurement = "tablespoon";
                }

                // Cup and Ounce
                else if (ingredient.measurement == "cup" && ingredient.quantity >= 8)
                {
                    ingredient.quantity = ConvertMeasurement(ingredient.quantity, "cup", "ounce");
                    ingredient.measurement = "ounce";
                }
                else if (ingredient.measurement == "ounce" && ingredient.quantity >= 1)
                {
                    ingredient.quantity = ConvertMeasurement(ingredient.quantity, "ounce", "cup");
                    ingredient.measurement = "cup";
                }

                // Ounce and Pound
                else if (ingredient.measurement == "ounce" && ingredient.quantity >= 16)
                {
                    ingredient.quantity = ConvertMeasurement(ingredient.quantity, "ounce", "pound");
                    ingredient.measurement = "pound";
                }
                else if (ingredient.measurement == "pound" && ingredient.quantity >= 1)
                {
                    ingredient.quantity = ConvertMeasurement(ingredient.quantity, "pound", "ounce");
                    ingredient.measurement = "ounce";
                }

                // Ounce and Gram
                else if (ingredient.measurement == "ounce" && ingredient.quantity >= 28.3495)
                {
                    ingredient.quantity = ConvertMeasurement(ingredient.quantity, "ounce", "gram");
                    ingredient.measurement = "gram";
                }
                else if (ingredient.measurement == "gram" && ingredient.quantity >= 1)
                {
                    ingredient.quantity = ConvertMeasurement(ingredient.quantity, "gram", "ounce");
                    ingredient.measurement = "ounce";
                }

                // Pound and Kilogram
                else if (ingredient.measurement == "pound" && ingredient.quantity >= 2.20462)
                {
                    ingredient.quantity = ConvertMeasurement(ingredient.quantity, "pound", "kilogram");
                    ingredient.measurement = "kilogram";
                }
                else if (ingredient.measurement == "kilogram" && ingredient.quantity >= 1)
                {
                    ingredient.quantity = ConvertMeasurement(ingredient.quantity, "kilogram", "pound");
                    ingredient.measurement = "pound";
                }

                // Liter and Milliliter
                else if ((ingredient.measurement == "liter" || ingredient.measurement == "l" || ingredient.measurement == "L") && ingredient.quantity >= 1000)
                {
                    ingredient.quantity = ConvertMeasurement(ingredient.quantity, ingredient.measurement, "milliliter");
                    ingredient.measurement = "milliliter";
                }
                else if (ingredient.measurement == "milliliter" && ingredient.quantity >= 1)
                {
                    ingredient.quantity = ConvertMeasurement(ingredient.quantity, "milliliter", "liter");
                    ingredient.measurement = "liter";
                }

                // Liter and Cup
                else if ((ingredient.measurement == "liter" || ingredient.measurement == "l" || ingredient.measurement == "L") && ingredient.quantity >= 4.22675)
                {
                    ingredient.quantity = ConvertMeasurement(ingredient.quantity, ingredient.measurement, "cup");
                    ingredient.measurement = "cup";
                }
                else if (ingredient.measurement == "cup" && ingredient.quantity >= 1)
                {
                    ingredient.quantity = ConvertMeasurement(ingredient.quantity, "cup", "liter");
                    ingredient.measurement = "liter";
                }

                // Quart and Cup
                else if ((ingredient.measurement == "quart" || ingredient.measurement == "qt") && ingredient.quantity >= 4)
                {
                    ingredient.quantity = ConvertMeasurement(ingredient.quantity, ingredient.measurement, "cup");
                    ingredient.measurement = "cup";
                }
                else if (ingredient.measurement == "cup" && ingredient.quantity >= 1)
                {
                    ingredient.quantity = ConvertMeasurement(ingredient.quantity, "cup", "quart");
                    ingredient.measurement = "quart";
                }

                // Gallon and Quart
                else if ((ingredient.measurement == "gallon" || ingredient.measurement == "gal") && ingredient.quantity >= 4)
                {
                    ingredient.quantity = ConvertMeasurement(ingredient.quantity, ingredient.measurement, "quart");
                    ingredient.measurement = "quart";
                }
                else if (ingredient.measurement == "quart" && ingredient.quantity >= 1)
                {
                    ingredient.quantity = ConvertMeasurement(ingredient.quantity, "quart", "gallon");
                    ingredient.measurement = "gallon";
                }

                // Gallon and Cup
                else if ((ingredient.measurement == "gallon" || ingredient.measurement == "gal") && ingredient.quantity >= 16)
                {
                    ingredient.quantity = ConvertMeasurement(ingredient.quantity, ingredient.measurement, "cup");
                    ingredient.measurement = "cup";
                }
                else if (ingredient.measurement == "cup" && ingredient.quantity >= 1)
                {
                    ingredient.quantity = ConvertMeasurement(ingredient.quantity, "cup", "gallon");
                    ingredient.measurement = "gallon";
                }
            }
        }
//----------------------------------------------------------------------------------------->
        //calculates the total calories of the recipe
        public void calorieCalculation(recipe newRecipe, ingredient newIngredient)
        {
            
            newRecipe.totalCalories += newIngredient.calories;
            if (newRecipe.totalCalories > 300)
            {
                CalorieExceeded?.Invoke(newRecipe);
            }   
            
        }
//----------------------------------------------------------------------------------------->
        public void NotifyCalorieExceeded(recipe recipeName)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Caution: The recipe '{recipeName}' has exceeded 300 calories.");
            Console.ResetColor();
        }
//----------------------------------------------------------------------------------------->
        //calculates the calorie information of the recipe
        public void calInfo(recipe uniChoice)
        {
            if (uniChoice.totalCalories < 500)
            {
                Console.WriteLine("This recipe has a low amount of calories in it.");
            }
            else if (uniChoice.totalCalories >= 500 && uniChoice.totalCalories < 1000)
            {
                Console.WriteLine("This recipe has a moderate amount of calories in it.");
            }
            else
            {
                Console.WriteLine("This recipe has a large amount of calories in it. BEWARE! HEALTH RISK!");
            }
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
                        recipeInputDetails();
                        break;
                    case 2:
                        recipePrint();
                        break;
                    case 3:
                        recipeScale();
                        break;
                    case 4:
                        resetScale();
                        break;
                    case 5:
                        resetRecipe();
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
