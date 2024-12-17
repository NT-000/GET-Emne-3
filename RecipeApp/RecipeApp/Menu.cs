namespace RecipeApp
{
    internal class Menu
    {
        public Menu()
        {
            StartMenu();
        }

        public void StartMenu()
        {
            bool isRunning = true;
            var recipeMan = new RecipeManager();
            while (isRunning)
            {
                Console.WriteLine("1.Show for all recipes");
                Console.WriteLine("2.Search menu");
                Console.WriteLine("3.Add recipe");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        recipeMan.ShowAllRecipes();
                        break;
                    case '2':
                        SearchMenu(recipeMan);
                        break;
                    case '3':
                        recipeMan.AddRecipe();
                        break;
                    default:
                        Console.WriteLine("Pick a valid number.");
                        break;

                }
            }
        }

        void SearchMenu(RecipeManager recipeManager)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("1.Search for dish");
                Console.WriteLine("2.Search for ingredients");
                Console.WriteLine("3.Search by category");
                Console.WriteLine("Or type any other character to leave");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        Console.Clear();
                        recipeManager.SearchForDish();
                        break;
                    case '2':
                        Console.Clear();
                        recipeManager.SearchForRecipeIngredients();
                        break;
                    case '3':
                        recipeManager.SearchForCategory();
                        break;
                    default:
                        isRunning = false;
                        break;

                }
            }
        }
    }
}
