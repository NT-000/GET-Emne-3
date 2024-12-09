namespace BossFight
{
    internal class Arena
    {
        public static int TurnCounter = 0;
        private Fighter SelectedFighter { get; set; }
        public static int Counter = 0;
        public Arena()
        {
            var hero = new Fighter("Hero", 100, 20, 40);
            var boss = new Fighter("Boss", 400, 10);
            var random = new Random();
            bool isRunning = true;

            while (true)
            {   
                IncreaseTurnCounter();
                
                Console.WriteLine($"\nTurn {TurnCounter}\n");
                Console.ResetColor();
                CheckCounter();
                Console.ForegroundColor = ConsoleColor.White;
                ShowStatusBars(hero, boss);
                Console.WriteLine("HERO actions:");
                Console.WriteLine("\n1.Attack\n");
                Console.WriteLine("2.Rest\n");
                Console.WriteLine("3.Show inventory/Use item\n");
                if (Counter == 0)
                {
                    Console.Clear();
                    TurnHero(hero, boss, random);
                    Console.ReadKey();
                }

                if (Counter == 1)
                {
                    Console.Clear();
                    boss.BossAttack(hero, random);
                    
                }
            }
        }

        private void TurnHero(Fighter hero, Fighter boss, Random random)
        {
            bool isRunning;
            int inputChoice = int.Parse(Console.ReadLine());

            
            Console.Clear();
            switch (inputChoice)
            {

                case 1:
                    hero.HeroAttack(boss, random);
                    break;
                case 2:
                    hero.RestFighter(hero,boss);
                    break;
                case 3:
                    hero.ShowInventory();
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Bye!");
                    Environment.Exit(0);
                    break;
            }
        }

        private void ShowStatusBars(Fighter hero, Fighter boss)
        {
            Console.WriteLine("---------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine($"\nIt's {CheckCounterForName(hero, boss)} turn\n");
            Console.ResetColor();
            Console.Write($"HERO HP:{hero.HpBarHero()} {hero.GetHealth()}%    ");
            Console.ResetColor();
            Console.Write($"Stamina:{hero.StaminaBarHero()} {hero.GetStamina() * 2.5}%\n");
            Console.ResetColor();
            Console.WriteLine("");
            Console.Write($"BOSS HP:{boss.HpBarBoss()} {boss.GetHealth() / 4}%    ");
            Console.ResetColor();
            Console.Write($"Stamina:{boss.StaminaBarBoss()} {boss.GetStamina() * 10}%\n");
            Console.ResetColor();
            Console.WriteLine("---------------------------------------------------------------------");
            Console.ResetColor();
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

        private void IncreaseTurnCounter()
        {
            TurnCounter++;
        }



    }
}
