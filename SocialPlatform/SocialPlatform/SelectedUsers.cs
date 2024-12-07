namespace SocialPlatform
{
    internal class SelectedUsers
    {
        private People SelectedUser { get; set; }
        private People SelectedFriend { get; set; }

        public void SetSelectedUser(People user)
        {
            SelectedUser = user;
        }
        public People GetSelectedUser()
        {
            return SelectedUser;
        }

        public void SetSelectedFriend(People friend)
        {
            SelectedFriend = friend;
        }
        public People GetSelectedFriend()
        {
            return SelectedFriend;
        }
        public void ResetSelectedUser()
        {
            SelectedUser = null;
            Console.WriteLine("User has logged out");
        }
        public void ShowFriends()
        {
            var currentUserFriendList = SelectedUser.GetUserFriends();
            int counter = 1;
            Console.WriteLine("Your friends:");
            foreach (var friend in currentUserFriendList)
            {
                Console.WriteLine($"{counter}.Name: {friend.GetName()}");
                counter++;
            }
            Console.Clear();
            Console.WriteLine("Which friend-profile will you visit?");
            int index = int.Parse(Console.ReadLine());
            var friendInfo = currentUserFriendList[index-1];
            Console.WriteLine($"Welcome to {friendInfo.GetName()} profile page");
            Console.WriteLine($"Age: {friendInfo.GetAge()}");
            Console.WriteLine($"Vocation: {friendInfo.GetWorkPlace()}");

            foreach (var friend in friendInfo.GetUserFriends())
            {
                Console.WriteLine($"{friendInfo.GetName()} friends:");
                Console.WriteLine($"{friend.GetName()}");
            }
            
        }

        public void RemoveFriend()
        {
            var friendList = SelectedUser.GetUserFriends();
            int counter = 1;
            Console.WriteLine($"Hi, {GetSelectedUser().GetName()}, do you want to remove one of your friends?");
            foreach (var friend in friendList)
            {
                Console.WriteLine($"{counter}.Name:{friend.GetName()}");
                counter++;
            }

            Console.WriteLine("Which friend should we remove?");
            int input = int.Parse(Console.ReadLine());
            friendList.Remove(friendList[input - 1]);
            var foundFriend = friendList[input - 1];
            foundFriend.GetUserFriends().Remove(SelectedUser);

        }
        public void ShowCurrentUser()
        {
            if (SelectedUser != null)
            {
                Console.WriteLine($"Logged-in User: {SelectedUser.GetName()}");
                Console.WriteLine($"Age: {SelectedUser.GetAge()}, Workplace: {SelectedUser.GetWorkPlace()}");
            }
            else
            {
                Console.WriteLine("No user is currently logged in.");
            }
        }

    }
}
