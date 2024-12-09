namespace SocialPlatform
{
    internal class People
    {
        public string SearchResult { get; set; }
        private static int CounterId { get; set; }

        private List<People> _userFriends;
        private static List<People> _people = new List<People>();
        private int Id { get; set; }
        private string Name { get; set; }
        private int Age { get; set; }
        private string Work { get; set; }
        private string Password { get; set; }

        public People(string name, int age, string password)
        {
            Id = CounterId++;
            Name = name;
            Age = age;
            Work = GenerateWorkplace();
            Password = password;
            _userFriends = new List<People>();
        }

        public People()
        {
            _people = new List<People>()
            {
                new People("Jon", 20, "123"),
                new People("Kjell", 30, "123"),
                new People("Lars", 34, "123"),
                new People("Anna", 28, "123"),
                new People("Reidun", 78, "123"),
            };
        }

        public void RegisterPeople()
        {
            Console.WriteLine("Your name:");
            var inputName = Console.ReadLine();
            Console.WriteLine("Your Age:");
            int inputAge = int.Parse(Console.ReadLine());
            Console.WriteLine("Create a password");
            var inputPass = Console.ReadLine();

            _people.Add(new People(inputName, inputAge, inputPass));

        }

        public void ShowPeople()
        {
            foreach (var man in _people)
            {
                Console.WriteLine($"{man.Name} id: {man.Id} workplace: {man.Work} Password: {man.Password}");
            }
        }


        private string GenerateWorkplace()
        {
            string[] workPlace = ["Cashier", "Programmer", "Cop", "Firefighter", "Artist"];
            Random random = new Random();
            return workPlace[random.Next(workPlace.Length)];
        }

        public int GetPeopleId()
        {
            return Id;
        }

        public string GetName()
        {
            return Name;
        }

        public int GetAge()
        {
            return Age;
        }

        public string GetWorkPlace()
        {
            return Work;
        }

        public string GetPassword()
        {
            return Password;
        }

        public List<People> GetUserFriends()
        {
            return _userFriends;
        }

        public List<People> GetUserList()
        {
            return _people;
        }

        public void SearchForPeople(SelectedUsers selectedUser)
        {
            var currentUser = selectedUser.GetSelectedUser();
            int counter = 1;
            Console.WriteLine("Search for other users");
            string inputSearch = Console.ReadLine();


            var searchResult = _people.Where(user => user.GetName().Contains(inputSearch)).ToList();

            if (searchResult.Count != 0)
            {
                Thread.Sleep(300);
                Console.Write("▌▌▌▌▌");
                Thread.Sleep(200);
                Console.Write("▌▌▌▌▌▌");
                Thread.Sleep(200);
                Console.Write("▌▌▌▌▌▌▌");
                Thread.Sleep(300);
                Console.WriteLine("Searching...\n");
                Thread.Sleep(300);
                Console.Write("▌▌▌▌▌▌▌▌");
                Thread.Sleep(200);
                Console.Write("▌▌▌▌▌▌▌▌");
                Thread.Sleep(200);
                Console.Write("▌▌▌▌▌▌▌▌▌▌▌▌▌▌");
                Thread.Sleep(300);
                Console.WriteLine("Search Complete!");
                Thread.Sleep(1000);
                Console.Clear();
                foreach (var person in searchResult)
                {
                    if (person != currentUser && !currentUser.GetUserFriends().Contains(person))
                    {   Thread.Sleep(500);
                        Console.WriteLine($"{counter}.Person: {person.Name}");
                        counter++;
                    }
                }

                Console.WriteLine("Would you like to add a friend? Enter first(y/n)");
                string input = Console.ReadLine();
                if (input.ToLower() == "y")
                {
                    Console.WriteLine("Input user");
                    int inputIndex = int.Parse(Console.ReadLine());
                    Console.Clear();
                    var potentialFriend = searchResult[inputIndex - 1];


                    if (currentUser != null && !currentUser.GetUserFriends().Contains(potentialFriend))
                    {
                        currentUser.GetUserFriends().Add(potentialFriend);
                        _people.Remove(currentUser);
                        potentialFriend.GetUserFriends().Add(currentUser);
                        _people.Remove(potentialFriend);
                        Thread.Sleep(700);
                        Console.WriteLine($"\n{potentialFriend.GetName()} was just added to {selectedUser.GetSelectedUser().GetName()}'s friend list!\n");
                    }
                }
                else if (input.ToLower() == "n")
                {
                    Console.WriteLine("Return to menu");

                }

            }
            else
            {
                Console.WriteLine("No search match");
            }
        }


    }
}
