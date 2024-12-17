namespace RecipeApp
{
    internal class RecipeManager
    {
        public List<Recipe> Recipes { get; private set; }

        private string line = new ('_', 60);

        public RecipeManager()
        {
            Recipes =
                [
                    new Recipe(1,"Tomato soup", "Soup of tomatoes", new List<Ingredient>
                        {new Ingredient("Tomato", 200, "Grams"), new Ingredient("Water",200, "Dl")}, "Weekend"),

                    new Recipe(2,"Potato soup", "Soup of Potatoes", new List<Ingredient>
                        {new Ingredient("Potato", 200,"Grams"), new Ingredient("Water",200, "Dl")}, "Weekend"),

                    new Recipe(3,"French soup", "Soup of from the french cuisine", new List<Ingredient>
                        {new Ingredient("Onion", 300, "Grams"), new Ingredient("Milk",3, "Dl")}, "Weekend"),

                    new Recipe(4,"Taco", "Soup of tomatoes", new List < Ingredient >
                        { new Ingredient("Meat", 200, "Grams"), new Ingredient("Spice", 5, "Grams") }, "Weekday"),
                    new Recipe(5,"Corn stew", "Delicious corn stew from Granny's secret recipe", new List < Ingredient >
                        { new Ingredient("Corn", 500, "Grams"), new Ingredient("Spice", 5, "Grams") }, "Vegetarian"),
                    new Recipe(6,"Caesar salad", "Freshly cut lettuce with chicken breast.", new List < Ingredient >
                        { new Ingredient("Chicken", 200, "Grams"), new Ingredient("Spice", 5, "Grams"), new Ingredient("Lettuce", 200, "Grams") }, "Weekday"),
                    new Recipe(7,"Shepard's pie", "Minced meat with mashed sweetpotato and spices.", new List < Ingredient >
                        { new Ingredient("Sweetpotato", 200, "Grams"), new Ingredient("Meat", 1000, "Grams"), new Ingredient("Salt", 50, "Grams") }, "Homecooked"),
                    new Recipe(8,"Pie", "Lovely dessert pie, baked with great care.", new List < Ingredient >
                        { new Ingredient("Cinnamon", 20, "Grams"), new Ingredient("Sugar", 1000, "Grams"), new Ingredient("Salt", 10, "Grams") }, "Dessert")
                ];
        }

        public void AddRecipe()
        {
            bool isDone = false;
            Console.WriteLine("Add a new recipe");
            Console.WriteLine("Name of recipe");
            string name = Console.ReadLine();
            Console.WriteLine("Describe the dish");
            string description = Console.ReadLine();
            var list = new List<Ingredient>();
            Console.WriteLine("Add ingredient");
            while (!isDone)
            {
                Console.WriteLine("Name");
                var ingredientName = Console.ReadLine();
                Console.WriteLine("Quantity of ingredient");
                int quantity = Convert.ToInt32(Console.ReadLine());
                string unit = Console.ReadLine();
                list.Add(new Ingredient(ingredientName, quantity, unit));
                Console.WriteLine($"You added {quantity} of {ingredientName} to the recipe");
                Console.WriteLine("Want to add another ingredient? (y/n) \n");
                var answer = Console.ReadKey(true).KeyChar;
                if (answer != 'y')
                {
                    isDone = true;
                }

            }

            Console.WriteLine("Which category is the dish?");
            string category = Console.ReadLine();
            var id = Recipes.Count + 1;
            Recipes.Add(new Recipe(id,name, description, list, category));
            Console.WriteLine("Recipe added to List");
        }

        public void ShowAllRecipes()
        {
            Console.WriteLine("Here are all your recipes:");
            foreach (var r in Recipes)
            {
                Console.WriteLine($"{r.Id}.{r.Name}");
            }
            Console.WriteLine("Type in id for dish");
            int inputId = Convert.ToInt32(Console.ReadLine());
            if (inputId != null)
            {
                var dish = Recipes[inputId - 1];
                Console.WriteLine($"Recipe info\n");
                Console.WriteLine($"Name:{dish.Name}");
                Console.WriteLine($"Description:{dish.Description}");
                Console.WriteLine("Ingredients:");
                foreach (var i in dish.Ingredient)
                {
                    Console.Write($"{i.Name}, {i.Quantity} {i.UnitType}\n");
                }
                Console.WriteLine($"Category:{dish.Category}");
                Console.WriteLine($"{line}");
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }

        public void SearchForCategory()
        {
            Console.WriteLine("Search for category");
            var inputSearch = Console.ReadLine().ToLower();
            var result = Recipes.Where(recipe => recipe.Category.ToLower().Contains(inputSearch)).ToList();
            foreach (var r in result)
            {
                Console.WriteLine($"Dish:{r.Name}\nCategory:{r.Category}");
                Console.WriteLine($"{line}");
            }
        }


        public void SearchForRecipeIngredients()
        {
            Console.WriteLine("Searchresult for ingredients in dish:");
            Console.WriteLine($"{line}");
            var inputSearch = Console.ReadLine().ToLower();
            var result = Recipes.Where(i => i.Ingredient.Any(ingredient => ingredient.Name.ToLower().Contains(inputSearch))).ToList();
            Console.WriteLine($"You searched for {inputSearch}");
            foreach (var r in result)
            {
                Console.WriteLine($"Name:{r.Name}");
                Console.WriteLine("Ingredients:");
                foreach (var i in r.Ingredient)
                {
                    Console.WriteLine($"{i.Name} - {i.Quantity},{i.UnitType}");
                }
                Console.WriteLine($"{line}");
            }
        }

        public void SearchForDish()
        {
            Console.WriteLine("Search for dish");
            var inputSearch = Console.ReadLine().ToLower();
            var result = Recipes.Where(dish => dish.Name.ToLower().Contains(inputSearch)).ToList();
            foreach (var dish in result)
            {
                Console.WriteLine($"{dish.Name}");
                Console.WriteLine($"{line}");
            }
        }
    }
}
