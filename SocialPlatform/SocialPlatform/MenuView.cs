namespace SocialPlatform
{
    internal class MenuView
    {
        public MenuView(SelectedUsers selectedUser)
        {
            People people = new People();
            bool isRunning = true;
            while (isRunning)
            {

                Console.WriteLine("\n1.Show people\n");
                Console.WriteLine("2.Search for people/ Add friend\n");
                Console.WriteLine("3.Show my friends / Go to friend-page\n");
                Console.WriteLine("4.Show my info\n");
                Console.WriteLine("5.Remove friend\n");
                Console.ResetColor();
                Console.WriteLine("Other: log out\n");

                var inputChoice = int.Parse(Console.ReadLine());
                switch (inputChoice)
                {
                    case 1:
                        Console.Clear();
                        people.ShowPeople();
                        break;
                    case 2:
                        Console.Clear();
                        people.SearchForPeople(selectedUser);
                        break;
                    case 3:
                        Console.Clear();
                        selectedUser.ShowFriends();
                        break;
                    case 4:
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        selectedUser.RemoveFriend();
                        break;
                    default:
                        isRunning = false;
                        selectedUser.ResetSelectedUser();
                        break;
                }
            }
        }

    }
}
