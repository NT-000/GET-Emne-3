namespace ClickerGame
{
    internal class BuySuperUpgrade : ICommand
    {
        public char Key { get; set; } ='s';
        private int PointsSuperUpgrade { get; set; }

        public BuySuperUpgrade()
        {
            PointsSuperUpgrade = 100;
        }

        public void Run(ClickerGame clicker)
        {
            if (clicker.Sum >= PointsSuperUpgrade)
            {
                clicker.UpgradeBig();
            }
        }
    }
}
