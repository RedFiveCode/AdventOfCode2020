using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day21
{
    class FoodReader
    {
        public List<Food> ReadFile(string filename)
        {
            var lines = File.ReadAllLines(filename);

            var foods = new List<Food>();

            foreach (var line in lines)
            {

            
            }

            return foods;
        }

        private Food ParseLine(string line)
        {
            var regex = new Regex(@"(.+ )\(contains (.*(, )?)\)");

            var match = regex.Match(line);

            if (!match.Success)
            {
                throw new ArgumentOutOfRangeException();
            }

            var ingredients = match.Groups[1].Value; // "mxvkd kfcds sqjhc nhms"
            var allergens = match.Groups[2].Value;// "dairy, fish"



            return null;
        }

        private List<string> ParseIngredients(string text)
        {
            var ingredientList = new List<string>();

            var regex = new Regex(@"(.+) ");

            var match = regex.Match(text);

            if (!match.Success)
            {
                throw new ArgumentOutOfRangeException();
            }

            foreach (var m in match.Groups)
            {
                ingredientList.Add(m.ToString());
            }

            return ingredientList;
        }

        private List<string> ParseAllergens(string text)
        { 
            // "mxmxvkd kfcds sqjhc nhms (contains dairy, fish)"
            // "mxmxvkd kfcds sqjhc nhms (contains dairy, fish, foo)"
            // "trh fvjkl sbzzf mxmxvkd (contains dairy)"

            var ingredientList = new List<string>();

            var regex = new Regex(@"\(contains (.*)\)");

            var match = regex.Match(text);

            if (!match.Success)
            {
                throw new ArgumentOutOfRangeException();
            }

            foreach (var m in match.Groups)
            {
                ingredientList.Add(m.ToString());
            }

            return ingredientList;
        }
    }
    class Food
    {
        private List<string> _ingredients = new List<string>();
        private List<string> _allergens = new List<string>();

        public void AddIngredient(string ingredient)
        {
            _ingredients.Add(ingredient);
        }

        public void AddAllergen(string allergen)
        {
            _allergens.Add(allergen);
        }

        public IEnumerable<string> Ingredients
        {
            get { return _ingredients; }
        }

        public IEnumerable<string> Allergens
        {
            get { return _allergens; }
        }

    }
}
