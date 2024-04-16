using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FoodApp.FoodAppWorker;

namespace FoodApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            recipe newRecipe = new recipe();
            FoodAppWorker foodAppWorker = new FoodAppWorker();
            foodAppWorker.recipeInputDetails(newRecipe);
            foodAppWorker.recipePrint(newRecipe);
        }
    }
}
