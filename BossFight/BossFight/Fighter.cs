namespace BossFight
{
    internal class Fighter
    {
        private string ActionDialog { get; set; }
        private string Name { get; set; }
        private int Health { get; set; }
        private int Strength { get; set; }
        private int Stamina { get; set; }

        private int Defence { get; set; }

        private int level { get; set; }

        private List<Potion> _potionList { get; set; }
        private List<Fighter> FighterList { get; set; } = new List<Fighter>();

        private List<Equipment> _equipment { get; set; } = new List<Equipment>();

        public Fighter(string name, int health, int strength, int stamina)
        {
            var potion = new Potion();
            Name = name;
            Health = health;
            Strength = strength;
            Stamina = stamina;
            Defence = 5;
            _potionList = new List<Potion>()
            {
                new("Health Potion","Health"),
                new("Health Potion","Health"),
                new("Health Potion","Health"),
                new("Stamina Potion","Stamina"),

            };
        }

        public Fighter(string name, int health, int stamina)
        {
            Name = name;
            Health = health;
            Strength = 30;
            Stamina = stamina;

        }

        public Fighter() //list for possible new enemy/ally
        {
            var hero = new Fighter("Hero", 100, 20, 40);
            var boss = new Fighter("Slack", 400, 10);
            FighterList.Add(hero);
            FighterList.Add(boss);
        }

        public string GetName()
        {
            return Name;
        }

        public int GetHealth()
        {
            return Health;
        }

        public int GetStrength()
        {
            return Strength;
        }

        public int GetStamina()
        {
            return Stamina;
        }

        public List<Potion> GetHeroPotionList()
        {
            return _potionList;
        }

        public void HeroAttack(Fighter hero, Fighter boss, Random random)
        {
            int chance = random.Next(0, 101);
            if (hero.Stamina < 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{hero.Name} got to rest!");
                hero.RestFighter(hero, boss);
                Arena.Counter++;
                Console.ResetColor();
            }


            int hitSuccessRate = 100 - boss.Defence;
            if (hero.Stamina >= 10 && hitSuccessRate >= chance)
            {
                boss.Health -= hero.Strength;
                hero.Stamina -= 10;
                hero.Stamina = Math.Max(hero.Stamina, 0);
                boss.Health = Math.Max(boss.Health, 0);
                Arena.Counter++;
                Console.WriteLine($"{hero.Name} hit {boss.Name} and caused {boss.Strength} damage!");
            }
            else
            {
                Console.WriteLine($"{hero.Name} missed {boss.Name} with their attack!");
            }


            if (boss.Health <= 0)
            {
                BossDie(boss, hero);
            }


        }

        public void ShowInventory(Fighter hero)
        {
            int num = 1;
            var heroList = hero._potionList;
            foreach (var potion in heroList)
            {
                Console.WriteLine($"{num}.{potion.GetPotionName()}");
                num++;
            }

            Console.WriteLine("Need to use some potions?");
            int inputChoice = int.Parse(Console.ReadLine());
            var choice = heroList[inputChoice - 1];

            Console.Clear();
            if (choice.GetPotionName() == "Health Potion")
            {
                HeroHealthHeal(hero);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"{choice.GetPotionName()} replenished 40 HP!");
                hero._potionList.Remove(choice);
                Console.ResetColor();
            }
            else if (choice.GetPotionName() == "Stamina Potion")
            {
                HeroStaminaHeal(hero);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"{choice.GetPotionName()} replenished 30 Stamina!");
                hero._potionList.Remove(choice);
                Console.ResetColor();
            }

            Console.WriteLine($"{hero.Name} Health: {hero.Health} Stamina: {hero.Stamina}");
        }

        private void HeroStaminaHeal(Fighter hero)
        {
            hero.Stamina += 30;
            hero.Stamina = Math.Max(hero.Stamina, 40);
            Arena.Counter++;
        }

        private void HeroHealthHeal(Fighter hero)
        {
            hero.Health += 40;
            hero.Health = Math.Min(hero.Health, 100);
            Arena.Counter++;
        }
        public void RestFighter(Fighter hero, Fighter boss)
        {
            if (Arena.Counter == 0)
            {
                hero.Stamina += 40;
                hero.Stamina = Math.Min(Stamina, 40);
                Console.WriteLine($"{hero.Name} restored 40 stamina points!\n");
                Arena.Counter++;
            }

            if (Arena.Counter == 1)
            {
                boss.Stamina += 10;
                boss.Stamina = Math.Min(Stamina, 10);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"{boss.Name} restored its stamina\n");
                Console.ResetColor();
                Arena.Counter++;
            }
        }

        private void HeroDie(Fighter hero)
        {
            Console.WriteLine("GAME OVER...");
            Console.WriteLine($"{hero.Name} got slain by boss...");
            Environment.Exit(0);
        }

        private int RandomStrengthBoss(Fighter boss)
        {
            Random random = new Random();
            int num = random.Next(0, 31);

            return num;
        }
        public void BossAttack(Fighter boss, Fighter hero, Random random)
        {
            int chance = random.Next(0, 101);
            int hitSuccessRate = 100 - hero.Defence;
            boss.Strength = RandomStrengthBoss(boss);
            if (boss.Stamina < 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{boss.Name} got to rest!");
                hero.RestFighter(hero, boss);
                Arena.Counter++;
                Console.ResetColor();
            }

            else if (boss.Stamina >= 10 && hitSuccessRate >= chance)
            {
                hero.Health -= boss.Strength;
                hero.Health = Math.Max(hero.Health, 0);
                boss.Stamina -= 10;
                hero.Stamina = Math.Max(hero.Stamina, 0);
                Arena.Counter++;
                Console.WriteLine($"{boss.Name} hit {hero.Name} and caused {boss.Strength} damage, {ReturnTextDamageBoss(boss, hero, random)}");
            }
            else
            {
                Console.WriteLine($"{hero.Name} missed {boss.Name} with their attack!");
            }
            if (hero.Health <= 0)
            {
                HeroDie(hero);
            }

            else
            {
                Console.WriteLine($"{boss.Name} has {boss.Stamina} left and needs to rest");
            }

        }

        private void RandomMissChance(Fighter hero, Fighter boss, Random random)
        {
            int chance = random.Next(0, 101);
            if (Arena.Counter == 0)
            {
                int hitSuccessRate = 100 - boss.Defence;
                if (hitSuccessRate >= chance)
                {
                    hero.Health -= boss.Strength;
                    boss.Stamina -= 10;
                    Arena.Counter++;
                    Console.WriteLine(
                        $"{boss.Name} hit {hero.Name} and caused {boss.Strength} damage, {ReturnTextDamageBoss(boss, hero, random)}");
                }
                else
                {
                    Console.WriteLine($"{hero.Name} missed {boss.Name} with their attack!");
                }
            }

            if (Arena.Counter == 1)
            {
                int successRate = 100 - hero.Defence;
                if (successRate >= chance)
                {
                    Console.WriteLine($"Hit success, {boss.Strength} damage dealt!");
                }
                else
                {
                    Console.WriteLine($"{boss.Name} missed, no damage dealt.");
                }
            }
        }

        //private void BossRest(Fighter boss)
        //{
        //    boss.Stamina += 10;
        //}

        private string ReturnTextDamageBoss(Fighter boss, Fighter hero, Random random)
        {

            if (boss.Strength <= 10)
            {
                return RandomAnswersWeakAttack(random);
            }

            if (boss.Strength >= 10 && 20 >= boss.Strength)
            {
                return RandomAnswersAverageAttack(random);
            }
            if (boss.Strength >= 20 && 30 >= boss.Strength)
            {
                return RandomAnswersStrongAttack(random, hero);
            }

            return $"{boss.Name} deals a devasting strike tyo {hero.Name}!";
        }

        private string RandomAnswersWeakAttack(Random random)
        {
            string[] weakAnswers = ["what an embarrassing attack", "what an incredibly weak attack", "what a pathetic excuse of an attack", "what a joke!"];
            int num = random.Next(weakAnswers.Length);

            return weakAnswers[num];

        }

        private string RandomAnswersAverageAttack(Random random)
        {
            string[] averageAnswers =
            [
                "average...", "3/5...", "that hurt a little", "that was an OKAY strike", "uhh, that was a normal strike"
            ];
            int index = random.Next(averageAnswers.Length);
            return averageAnswers[index];
        }

        private string RandomAnswersStrongAttack(Random random, Fighter hero)
        {
            string[] greatAnswers = ["what a devasting strike!", $"{hero.Name} got mauled!", "auuchh, that was a crushing strike!", "what a lethal strike!", $"dangerous for {hero.Name} now", "crushing blow!!!", $"will {hero.Name} survive"];
            int index = random.Next(greatAnswers.Length);
            return greatAnswers[index];
        }


        private void BossDie(Fighter boss, Fighter hero)
        {
            if (boss.Health <= 0)
            {
                Console.WriteLine("YOU HAVE WON!");
                Console.WriteLine($"{boss.Name} got slain by {hero.Name}...");
                Environment.Exit(0);
            }
        }

        public string HpBarHero(Fighter hero)
        {
            Console.ResetColor();
            var hpBar = "";
            for (var i = 0; i < hero.Health; i += 10)
            {
                hpBar += "\u258c";
            }
            if (hero.Health <= 25)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            else if (hero.Health <= 50)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            return hpBar;

        }
        public string StaminaBarHero(Fighter hero)
        {
            Console.ResetColor();
            var staminaBar = "";
            for (var i = 0; i < hero.Stamina; i += 4)
            {
                staminaBar += "\u258c";
            }
            if (hero.Stamina <= 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            else if (hero.Stamina <= 25)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            return staminaBar;
        }


        public string HpBarBoss(Fighter boss)
        {
            Console.ResetColor();
            var hpBar = "";
            for (double i = 0; i < boss.Health; i += 40)
            {
                hpBar += "\u258c";
            }
            if (boss.Health <= 100)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            else if (boss.Health <= 250)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            return hpBar;
        }
        public string StaminaBarBoss(Fighter boss)
        {
            Console.ResetColor();
            var staminaBar = "";
            for (var i = 0; i < boss.Stamina; i += 1)
            {
                staminaBar += "\u258c";
            }
            if (boss.Stamina <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            else if (boss.Stamina <= 5)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            return staminaBar;
        }

    }
}
