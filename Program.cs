using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FoodApp.FoodAppWorker;

namespace FoodApp
{
    /// <summary>
    /// Joshua Gain 
    /// ST10369044
    /// PROG6221
    /// Group 1
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
    /// Link:https://www.youtube.com/watch?v=m863B7Eb6I4
    /// </Refernces>
    internal class Program
    {
        static void Main(string[] args)
        {
            recipe newRecipe = new recipe();
            FoodAppWorker foodAppWorker = new FoodAppWorker();
            foodAppWorker.Menu();
        }
    }
}
//---------------------------------------END-OF-FILE--------------------------------------->