namespace BossFight
{
    internal class Potion
    {
        private string Name { get; set; }
        private string Type { get; set; }
        private int Health { get; set; }
        private int Stamina { get; set; }

        public Potion()
        {

        }
        public Potion(string name, string type)
        {
            Name = name;
            Type = type;

        }

        public int GetHealth() { return Health; }
        public int GetStamina() { return Stamina; }

        public string GetType()
        {
            return Type;
        }

        public string GetPotionName()
        {
            return Name;
        }
    }
}
