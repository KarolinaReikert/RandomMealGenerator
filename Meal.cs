using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomMealGenerator
{
    // Example 1
    //public class Meal
    //{
    //    public string Name { get; set; }
    //    public int Price { get; set; }
    //    public string[] Recipe { get; set; }
    //    public string Country { get; set; }
    //    public int Id { get; set; }
    //}

    // Example 2
    public class Rootobject
    {

        public string q { get; set; }
        public int from { get; set; }
        public int to { get; set; }
        public bool more { get; set; }
        public int count { get; set; }
        public Hit[] hits { get; set; }

    }

    public class Hit
    {
        public Recipe recipe { get; set; }
    }



    public class Recipe
    {
        public string label { get; set; }
        public string source { get; set; }
        public string url { get; set; }
        public string[] ingredientLines { get; set; }
        public Ingredient[] ingredients { get; set; }
        public float calories { get; set; }
        public float totalWeight { get; set; }
        public float totalTime { get; set; }
        public string[] cuisineType { get; set; }
        public string[] mealType { get; set; }
        public string[] dishType { get; set; }


        public class Ingredient
        {
            public string text { get; set; }
            public float quantity { get; set; }
            public string measure { get; set; }
            public string food { get; set; }
            public float weight { get; set; }
            public string foodCategory { get; set; }
            public string foodId { get; set; }
        }
    }
}
