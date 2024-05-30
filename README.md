# FoodApp

## Overview

FoodApp is a console application that allows users to manage recipes. It allows users to add recipes with multiple ingredients and steps, print recipe details, scale ingredient quantities, reset ingredient scales, and reset recipes to their original details.

## Instructions

1. **Adding a Recipe**: Choose option 1 from the menu and follow the prompts to input the name, ingredients, and steps for the recipe.

2. **Printing a Recipe**: Choose option 2 from the menu to print the details of a previously added recipe.

3. **Scaling Recipe Ingredients**: Choose option 3 from the menu to scale the quantities of all ingredients in a recipe by a specified factor.

4. **Resetting Recipe Scale**: Choose option 4 from the menu to reset the scaled quantities of ingredients back to their original values.

5. **Resetting Recipe**: Choose option 5 from the menu to reset all added recipes to their original details.

6. **Exiting the Application**: Choose option 6 from the menu to exit the application.

## Running the Application

To run the FoodApp:

1. Clone or download the FoodApp repository.

2. Open the solution in Visual Studio or your preferred C# development environment.

3. Build the solution to compile the application.

4. Run the application by starting the program (usually by pressing F5 or selecting "Start Debugging" from the menu).

5. Follow the on-screen instructions to interact with the FoodApp.

## Dependencies

The FoodApp is written in C# and does not have any external dependencies beyond the standard .NET framework.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## GitHub link

https://github.com/JoshieBoy454/FoodApp.git

## GitHub commits

![Screenshot (29)](https://github.com/JoshieBoy454/FoodApp/assets/130691091/1639bfcb-6f8c-4bcc-9c99-934f6916e778)

## Update v.0.2

## Instructions

1. **Adding a Recipe**: Choose option 1 from the menu and follow the prompts to input the name, ingredients, quantity, calories, food group and steps.

2. **Printing a Recipe**: Choose option 2 from the menu to be directed to a list of recipes to choose from or optionally to search for a specific recipe, it will then print the details the selected recipe.

3. **Scaling Recipe Ingredients**: Choose option 3 from the menu to to be directed to a list of recipes to choose from or optionally to search for a specific recipe, it will then scale the quantities of all ingredients in a recipe by a specified factor.

4. **Resetting Recipe Scale**: Choose option 4 from the menu to to be directed to a list of recipes to choose from or optionally to search for a specific recipe, it will then reset the scaled quantities of ingredients back to their original values.

5. **Resetting Recipe**: Choose option 5 from the menu to to be directed to a list of recipes to choose from or optionally to search for a specific recipe, it will then reset the selected recipe to it's original details.

6. **Exiting the Application**: Choose option 6 from the menu to exit the application.

## GitHub commits

![Screenshot (1)](https://github.com/JoshieBoy454/FoodApp/assets/130691091/b229e564-13c7-4306-9cff-ea2f74bf37b3)

## GitHub Link

https://github.com/JoshieBoy454/FoodApp.git

## Changes Part 1

he changes made to part 1 of the application have significantly improved its structure and functionality. By separating the ingredient and recipe classes, the codebase is now more organized and easier to maintain. The addition of better try-catch functionality, including two throw blocks, enhances error handling and provides a more robust user experience. The implementation of a dictionary for conversion functionality streamlines unit conversions between different measurements.

## Changes Part 2 

In part 2 of the application, additional enhancements have been made to further improve the user experience. Generic collections have been implemented, replacing arrays with generic lists for both steps and ingredients, allowing for more flexibility and efficiency in handling data. Users can now add multiple recipes, which are stored for the duration of the application's runtime, providing a convenient way to manage and access recipes. Furthermore, a method to display the total calorie count has been added, giving users a quick overview of the nutritional information of their recipes. Additionally, the system now notifies the user if the total calorie count of their ingredients exceeds 300, helping them make healthier choices and avoid excessive calorie intake. Overall, these changes contribute to a more user-friendly and functional application.
