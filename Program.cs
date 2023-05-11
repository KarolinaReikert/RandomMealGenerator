using RandomMealGenerator;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace RandomMealGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string json = @"
            //[
            //    {
            //        ""Name"": ""Omlette"",
            //        ""Price"": 4,
            //        ""Recipe"": [""eggs"", ""vegetables""],
            //        ""Country"": ""Italy""
            //    },
            //    {
            //        ""Name"": ""Cepelinai"",
            //        ""Price"": 7,
            //        ""Recipe"": [""meat"", ""potatoes"", ""milk"", ""salt""],
            //        ""Country"": ""Spain""
            //    },
            //    {
            //        ""Name"": ""Pizza"",
            //        ""Price"": 10,
            //        ""Recipe"": [""flour"", ""cheese"", ""tomatoes"", ""peper"", ""water""],
            //        ""Country"": ""Italy""
            //    },
            //    {
            //        ""Name"": ""Potatoe pancakes"",
            //        ""Price"": 3,
            //        ""Recipe"": [""potatoes"", ""eggs"", ""flour"", ""butter""],
            //        ""Country"": ""Lithuania""
            //    },
            //    {
            //        ""Name"": ""Soup"",
            //        ""Price"": 2,
            //        ""Recipe"": [""water"", ""vegetables"", ""meat""],
            //        ""Country"": ""Latvia""
            //    }
            //]";
            string jsonFilePath = "C:\\Users\\Admin\\Desktop\\.NET kursas\\VsStudioProjects\\RandomMealGenerator\\mealsData.json";
            string json = File.ReadAllText(jsonFilePath);
            Meal[] meals = JsonSerializer.Deserialize<Meal[]>(json);

            GetRandomRecepe(meals);

        }

        static void GetRandomRecepe(Meal[] meals)
        {
            if (meals != null)
            {
                Console.Write("Enter country: ");
                string input = Console.ReadLine();

                IEnumerable<Meal> selectedMeals = meals.Where(m => m.Country.ToLower() == input.ToLower());

               Console.WriteLine("------>" + selectedMeals.Count());


               Console.WriteLine("------>" + selectedMeals.First().Name);
               Meal[] test =  selectedMeals.ToArray();
               

                Random random = new Random();
                int randomIndex = random.Next();

               Console.WriteLine("====>" + randomIndex);
                Console.WriteLine("--------------------------------------");


                Console.WriteLine("Name: " + test[randomIndex].Name);

                Console.WriteLine("Price:" + test[randomIndex].Price);
                Console.WriteLine("===>" + test[randomIndex].Recipe.Length);

                /*
                for (int i = 0; i > 0; i++)
                {
                    
                }*/




                //Meal randomMeal = meals[random.Next(0, meals.Length)];
                if (selectedMeals.Any())
                {
                    foreach (var meal in selectedMeals)
                    {
                        Console.WriteLine($"Name: {meal.Name}");
                        Console.WriteLine($"Price: {meal.Price}");
                        if (meal.Recipe != null)
                        {
                            //Console.WriteLine("Recipe:");
                            //foreach (var recipe in selectedMeal.Recipe)
                            //{
                            //    Console.WriteLine(recipe);
                            //}

                            Console.WriteLine($"Recipe: {string.Join(", ", meal.Recipe)}");
                            //foreach (var recipe in randomMeal.Recipe)
                            //{
                            //   Console.WriteLine(recipe);
                            //}
                        }
                        Console.WriteLine("");
                    }
                }
                else
                {
                    Console.WriteLine($"Meal with country '{input}' not found!");
                }
                Console.ReadLine();
            }
        }
    }
}