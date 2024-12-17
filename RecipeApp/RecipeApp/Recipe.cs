namespace RecipeApp
{
    internal class Recipe
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<Ingredient> Ingredient { get; private set; }
        public string Category { get; private set; }

        public Recipe(int id, string name, string description, List<Ingredient> _ingredients, string category)
        {
            Id = id;
            Name = name;
            Description = description;
            Ingredient = _ingredients;
            Category = category;
        }
    }
}
