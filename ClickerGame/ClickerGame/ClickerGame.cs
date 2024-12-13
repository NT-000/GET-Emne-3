namespace ClickerGame
{
    public class ClickerGame
    {
        public int Sum = 0;
        int _pointsPerClick = 1;
        int _pointsPerClickIncrease = 1;



        public void ClickForPoints()
        {
            Sum += _pointsPerClick;
        }

        public void UpgradeSmall()
        {
            if (Sum < 10)
            {
                return;
            }
            Sum -= 10;
            _pointsPerClick += _pointsPerClickIncrease;
        }

        public void UpgradeBig()
        {
            if (Sum < 100)
            {
                return;
            }
            Sum -= 100;
            _pointsPerClickIncrease++;
        }
    }
}
