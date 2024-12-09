namespace BossFight
{
    internal class ActionMenu
    {
        public ActionMenu(Fighter hero, Fighter boss)
        {
            bool isRunning = true;

            while (true)
            {
                var inputChoice = int.Parse(Console.ReadLine());
                switch (inputChoice)
                {
                    case 1:
                        Console.WriteLine("Attack");
                        break;
                    case 2:
                        Console.WriteLine("Rest");
                        break;
                    case 3:
                        Console.WriteLine("Show inventory");
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Go back");
                        isRunning = false;
                        break;
                }
            }
        }
        public void BossAttack()
        {

        }

        public void BossDamage()
        {
        }

    }
}
