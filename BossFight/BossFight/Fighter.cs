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

        private int Level { get; set; }

        private List<Potion> _potionList { get; set; }
        private List<Fighter> FighterList { get; set; } = new List<Fighter>();

        private List<Equipment> _equipment { get; set; } = new List<Equipment>();

        public Fighter(string name, int health, int strength, int stamina)
        {
            Name = name;
            Health = health;
            Strength = strength;
            Stamina = stamina;
            Defence = 10;
            _potionList =
            [
                new("Health Potion", "Health"),
                new("Health Potion", "Health"),
                new("Health Potion", "Health"),
                new("Stamina Potion", "Stamina")

            ];
        }

        public Fighter(string name, int health, int stamina)
        {
            Name = name;
            Health = health;
            Strength = 30;
            Stamina = stamina;
            Defence = 10;

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

        public void HeroAttack(Fighter boss, Random random)
        {
            int chance = random.Next(0, 101);
            if (Stamina < 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Name} got to rest!");
                RestFighter(this,boss);
                Arena.Counter++;
                Console.ResetColor();
            }

            int hitSuccessRate = 100 - boss.Defence;
            if (Stamina >= 10 && hitSuccessRate >= chance)
            {
                boss.Health -= Strength;
                Stamina -= 10;
                boss.Health = Math.Max(boss.Health, 0);
                Stamina = Math.Max(Stamina, 0);
                Arena.Counter++;
                Console.WriteLine($"{Name} hit {boss.Name} and caused {Strength} damage!");
            }
            else
            {
                Console.WriteLine($"{Name} missed {boss.Name} with their attack!");
                Arena.Counter++;
            }


            if (boss.Health <= 0)
            {
                BossDie(this,boss);
            }


        }

        public void ShowInventory()
        {
            int num = 1;
            var heroList = _potionList;
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
                HeroHealthHeal(this);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"{choice.GetPotionName()} replenished 40 points of {Name}'s HP!");
                _potionList.Remove(choice);
                Console.ResetColor();
            }
            else if (choice.GetPotionName() == "Stamina Potion")
            {
                HeroStaminaHeal(this);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"{choice.GetPotionName()} replenished 30 points of {Name}'s Stamina!");
                _potionList.Remove(choice);
                Console.ResetColor();
            }

            Console.WriteLine($"{Name} Health: {Health} Stamina: {Stamina}");
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
                Stamina += 40;
                Stamina = Math.Min(Stamina, 40);
                Console.WriteLine($"{Name} restored 40 stamina points!\n");
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
            Console.Clear();
            Console.WriteLine("GAME OVER...");
            Console.WriteLine($"{hero.Name} got slain by boss...");
            Environment.Exit(0);
        }

        private int RandomStrengthBoss()
        {
            Random random = new Random();
            int num = random.Next(0, 31);

            return num;
        }
        public void BossAttack(Fighter hero, Random random)
        {
            int chance = random.Next(0, 101);
            int hitSuccessRate = 100 - hero.Defence;
            Strength = RandomStrengthBoss();
            if (Stamina < 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n{Name} got to rest!");
                hero.RestFighter(hero, this);
                Arena.Counter++;
                Console.ResetColor();
            }

            else if (Stamina >= 10 && hitSuccessRate >= chance)
            {
                hero.Health -= Strength;
                hero.Health = Math.Max(hero.Health, 0);
                Stamina -= 10;
                Arena.Counter++;
                Console.WriteLine($"{Name} hit {hero.Name} and caused {Strength} damage, {ReturnTextDamageBoss(hero, random)}");
            }
            else
            {
                Console.WriteLine($"{Name} missed {hero.Name} with their attack!");
                Arena.Counter++;
            }
            if (hero.Health <= 0)
            {
                HeroDie(hero);
            }

            else
            {
                Console.WriteLine($"\n{Name} has {Stamina} stamina left and needs to rest");
            }

        }


        private string ReturnTextDamageBoss(Fighter hero, Random random)
        {

            if (Strength <= 10)
            {
                return RandomAnswersWeakAttack(random);
            }

            if (Strength >= 10 && 20 >= Strength)
            {
                return RandomAnswersAverageAttack(random);
            }
            if (Strength >= 20 && 30 >= Strength)
            {
                return RandomAnswersStrongAttack(random, hero);
            }

            return $"{Name} deals a devasting strike to {hero.Name}!";
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

        public string HpBarHero()
        {
            Console.ResetColor();
            var hpBar = "";
            for (var i = 0; i < Health; i += 10)
            {
                hpBar += "\u258c";
            }
            if (Health <= 25)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            else if (Health <= 50)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            return hpBar;

        }
        public string StaminaBarHero()
        {
            Console.ResetColor();
            var staminaBar = "";
            for (var i = 0; i < Stamina; i += 4)
            {
                staminaBar += "\u258c";
            }
            if (Stamina <= 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            else if (Stamina <= 25)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            return staminaBar;
        }


        public string HpBarBoss()
        {
            Console.ResetColor();
            var hpBar = "";
            for (double i = 0; i < Health; i += 40)
            {
                hpBar += "\u258c";
            }
            if (Health <= 100)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            else if (Health <= 250)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            return hpBar;
        }
        public string StaminaBarBoss()
        {
            Console.ResetColor();
            var staminaBar = "";
            for (var i = 0; i < Stamina; i += 1)
            {
                staminaBar += "\u258c";
            }
            if (Stamina <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            else if (Stamina <= 5)
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
