using RandomMealGenerator;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;

namespace RandomMealGenerator
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            // Example 1
            //string jsonFilePath = "C:\\Users\\Admin\\Desktop\\.NET kursas\\VsStudioProjects\\RandomMealGenerator\\mealsData.json";
            //string json = File.ReadAllText(jsonFilePath);
            //Meal[] meals = JsonSerializer.Deserialize<Meal[]>(json);
            //GetRandomRecepe(meals);

            // Example 2
            Console.WriteLine("Choose a country: ");
            string country = Console.ReadLine();
            HttpClient client = new HttpClient();
            string response = client.GetStringAsync($"https://api.edamam.com/search?app_id=38c4fcc6&app_key=024de75c4492cec0c489343537b5e7ca&from=0&to=10&q={country}").Result;

            Rootobject ApiResultObject = JsonConvert.DeserializeObject<Rootobject>(response);
            GetRandomRecepe(ApiResultObject, country);
        }

        // Example 2
        public static void GetRandomRecepe(Rootobject ApiResultObject, string country)
        {
            if (ApiResultObject.hits.Length > 0)
            {
                // We are taking random from 0 to count.
                var recipe = ApiResultObject.hits.ElementAt(new Random().Next(0, ApiResultObject.hits.Count())).recipe;

                Console.WriteLine($"Recipe label: {recipe.label}"); //can put whatever info from meal.cs (gotten from API)
                Console.WriteLine($"Country: {country}");
                Console.WriteLine($"Recipe ingredients:");
                foreach (var ingredient in recipe.ingredientLines)//using foreach since the ingredients are in a list
                {
                    Console.WriteLine($"  {ingredient}");
                }
                Console.WriteLine($"Total calories: {recipe.calories}");
                Console.WriteLine($"Source: {recipe.source} | {recipe.url}");
            }
            else //gives if recipe count is 0
            {
                Console.WriteLine("sorry, no recipes found!");
            }
        }

        //Example 1
        //static void GetRandomRecepe(Meal[] meals)
        //{
        //    if (meals != null)
        //    {
        //        Console.Write("Enter country: ");
        //        string input = Console.ReadLine();

        //        // We are filtering by the country. 
        //        var selectedMeals = meals.Where(m => m.Country.ToLower() == input.ToLower());

        //        // Checking amount. If  0, will be else. 
        //        if (selectedMeals.Count() > 0)
        //        {
        //            // If we have more than 1 we will take random one of them else if 1 we will take the first one. 
        //            Meal selectedMeal = selectedMeals.Count() > 1 ? selectedMeals.ElementAt(new Random().Next(0, selectedMeals.Count())) : selectedMeals.First();

        //            // Showing the results.
        //            Console.WriteLine("Random meal selected: {0}", selectedMeal.Name);
        //            Console.WriteLine("Price: {0}", selectedMeal.Price);

        //            // Do we have recipe data.
        //            if (selectedMeal.Recipe != null)
        //            {
        //                Console.WriteLine($"Recipe: {string.Join(", ", selectedMeal.Recipe)}");
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("No meals found with that country.");
        //        }
        //        //    Console.ReadLine();
        //    }
        //}
    }
}