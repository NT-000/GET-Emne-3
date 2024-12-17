namespace RecipeApp
{
    internal class Ingredient
    {
        public string Name { get; private set; }
        public double Quantity { get; private set; }

        public string UnitType { get; private set; }

        public Ingredient(string name, int quantity, string unitType)
        {
            Name = name;
            Quantity = quantity;
            UnitType = unitType;
        }
    }
}
