namespace BossFight
{
    internal class Arena
    {
        private Fighter SelectedFighter { get; set; }
        public static int Counter = 0;
        public Arena()
        {

            var hero = new Fighter("Hero", 100, 20, 40);
            var boss = new Fighter("Boss", 400, 10);
            var potionClass = new Potion();
            var random = new Random();
            bool isRunning = true;

            while (true)
            {
                Console.ResetColor();
                CheckCounter();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\nIt's {CheckCounterForName(hero, boss)} turn\n");
                Console.ResetColor();
                Console.Write($"HERO HP:{hero.HpBarHero(hero)} {hero.GetHealth()}%    ");
                Console.ResetColor();
                Console.Write($"Stamina:{hero.StaminaBarHero(hero)} {hero.GetStamina() * 2.5}%\n");
                Console.ResetColor();
                Console.WriteLine("");
                Console.Write($"BOSS HP:{boss.HpBarBoss(boss)} {boss.GetHealth() / 4}%    ");
                Console.ResetColor();
                Console.Write($"Stamina:{boss.StaminaBarBoss(boss)} {boss.GetStamina() * 10}%\n");
                Console.ResetColor();
                Console.WriteLine("---------------------------------------------------------------------");
                Console.ResetColor();
                Console.WriteLine("\n1.Attack\n");
                Console.WriteLine("2.Rest\n");
                Console.WriteLine("3.Show inventory/Use item\n");
                var inputChoice = int.Parse(Console.ReadLine());
                Console.Clear();
                if (Counter == 0)
                {
                    SwitchHero(inputChoice, hero, boss, random, isRunning);
                }

                if (Counter == 1)
                {
                    SwitchBoss(inputChoice, hero, boss, random, isRunning);
                }

            }


        }

        void SwitchHero(int inputChoice, Fighter hero, Fighter boss, Random random, bool isRunning)
        {
            switch (inputChoice)
            {
                case 1:
                    Console.WriteLine("Attack");
                    hero.HeroAttack(hero, boss, random);
                    break;

                case 2:
                    Console.WriteLine("Rest");
                    hero.RestFighter(hero, boss);

                    break;
                case 3:
                    Console.WriteLine("Show inventory");
                    hero.ShowInventory(hero);
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Go back");
                    isRunning = false;
                    break;
            }
        }
        void SwitchBoss(int inputChoice, Fighter hero, Fighter boss, Random random, bool isRunning)
        {
            switch (inputChoice)
            {
                case 1:
                    Console.WriteLine("Attack");
                    boss.BossAttack(boss, hero, random);
                    break;
                case 2:
                    Console.WriteLine("Rest");
                    hero.RestFighter(hero, boss);
                    break;

                case 4:
                    break;
                default:
                    Console.WriteLine("Go back");
                    isRunning = false;
                    break;
            }
        }
        private string CheckCounterForName(Fighter hero, Fighter boss)
        {
            Console.ResetColor();
            if (Counter == 0)
            {
                return hero.GetName();
            }

            if (Counter == 1)
            {
                return boss.GetName();
            }

            return "No one";
        }

        private void CheckCounter()
        {
            if (Counter >= 2)
            {
                Counter = 0;

            }

        }



    }
}
