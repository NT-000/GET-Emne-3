namespace ClickerGame
{
    internal class BuyUpgrade : ICommand
    {
        public char Key { get; set; } = 'k';
        private int PointsBuyUpgrade { get; set; }

        public BuyUpgrade()
        {
            PointsBuyUpgrade = 10;
        }

       public void Run(ClickerGame clicker)
        {
            if (clicker.Sum >= PointsBuyUpgrade)
            {
                clicker.UpgradeSmall();
            }
        }
    }
}
