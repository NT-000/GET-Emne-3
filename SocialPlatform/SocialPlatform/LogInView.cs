namespace SocialPlatform
{
    internal class LogInView
    {
        public LogInView()
        {
            var user = new People();
            var selectedUser = new SelectedUsers();



            bool isRunning = true;
            while (isRunning)
            {   Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("#   _______                   __                                __              __       __                       __      __    __  _______  \r\n#  |       \\                 |  \\                              |  \\            |  \\     /  \\                     |  \\    |  \\  |  \\|       \\ \r\n#  | $$$$$$$\\  ______    ____| $$ _______    ______    _______ | $$   __       | $$\\   /  $$  ______    ______  _| $$_   | $$  | $$| $$$$$$$\\\r\n#  | $$__| $$ /      \\  /      $$|       \\  /      \\  /       \\| $$  /  \\      | $$$\\ /  $$$ /      \\  /      \\|   $$ \\  | $$  | $$| $$__/ $$\r\n#  | $$    $$|  $$$$$$\\|  $$$$$$$| $$$$$$$\\|  $$$$$$\\|  $$$$$$$| $$_/  $$      | $$$$\\  $$$$|  $$$$$$\\|  $$$$$$\\\\$$$$$$  | $$  | $$| $$    $$\r\n#  | $$$$$$$\\| $$    $$| $$  | $$| $$  | $$| $$    $$| $$      | $$   $$       | $$\\$$ $$ $$| $$    $$| $$    $$ | $$ __ | $$  | $$| $$$$$$$ \r\n#  | $$  | $$| $$$$$$$$| $$__| $$| $$  | $$| $$$$$$$$| $$_____ | $$$$$$\\       | $$ \\$$$| $$| $$$$$$$$| $$$$$$$$ | $$|  \\| $$__/ $$| $$      \r\n#  | $$  | $$ \\$$     \\ \\$$    $$| $$  | $$ \\$$     \\ \\$$     \\| $$  \\$$\\      | $$  \\$ | $$ \\$$     \\ \\$$     \\  \\$$  $$ \\$$    $$| $$      \r\n#   \\$$   \\$$  \\$$$$$$$  \\$$$$$$$ \\$$   \\$$  \\$$$$$$$  \\$$$$$$$ \\$$   \\$$       \\$$      \\$$  \\$$$$$$$  \\$$$$$$$   \\$$$$   \\$$$$$$  \\$$      \r\n#                                                                                                                                            \r\n#                                                                                                                                            \r\n#                                                                                                                                            \n");
                Console.WriteLine("1.Login\n");
                Console.WriteLine("2.Register new user\n");
                Console.WriteLine("3.Log Out\n");

                int input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Login\n");
                        LoginUser(selectedUser, user.GetUserList());
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Register\n");
                        user.RegisterPeople();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Logged out\n");
                        selectedUser.ResetSelectedUser();
                        break;
                    case 4:

                        isRunning = false;
                        break;
                }
            }
        }



        public void LoginUser(SelectedUsers selectedUser, List<People> peoples)
        {
            
            Console.WriteLine("Input name:\n");
            var inputName = Console.ReadLine();
            Console.WriteLine("Input password:\n");
            var inputPassword = Console.ReadLine();

            if (inputName == null || inputPassword == null)
            {
                Console.WriteLine("Empty inputfields, insert something");
            }

            var foundUser = peoples.FirstOrDefault(user => user.GetName() == inputName && user.GetPassword() == inputPassword);
            if (foundUser != null)
            {
                selectedUser.SetSelectedUser(foundUser);
                Thread.Sleep(300);
                Console.Write("▌▌▌▌▌");
                Thread.Sleep(200);
                Console.Write("▌▌▌▌▌▌");
                Thread.Sleep(200);
                Console.Write("▌▌▌▌▌▌▌");
                Thread.Sleep(300);
                Thread.Sleep(300);
                Console.Write("▌▌▌▌");
                Thread.Sleep(200);
                Console.Write("▌▌▌▌");
                Thread.Sleep(200);
                Console.Write("▌▌▌▌▌▌");
                Thread.Sleep(300);
                Console.WriteLine("Loading Complete!");
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine($"\nWelcome {selectedUser.GetSelectedUser().GetName()}!\n");
                new MenuView(selectedUser);
            }

            else
            {
                Console.WriteLine("Wrong login");
            }
        }
    }
}
