namespace OrganTransplantNew;

public class StartMenu
{

    

    public void Start(UserManager userManager, SelectedUser selectedUser,OperationManager opManager)
    {
        while (true)
        {
            Console.WriteLine("WELCOME TO 'BACK ALLEY ORGAN-TRANSPLANT CLINIC'!\n");
            Console.WriteLine("1.Show Patients");
            Console.WriteLine("2.Show Doctors");
            Console.WriteLine("3.Prepare and select patients and doctor for operation$$$");
            Console.WriteLine("4.See potential donor-list");
            Console.WriteLine("5.Exit");
            
            var input = Console.ReadKey(true).KeyChar;
            switch (input)
            {
                case '1':
                case '2':
                    Console.Clear();
                    userManager.ShowUsers(input);
                    break;
                case '3':
                    Console.Clear();
                    SelectPatientsAndDoctorMenu(userManager, selectedUser, opManager);
                    break;
                case '4':
                    Console.Clear();
                    CheckAndShowMatches(userManager, selectedUser, opManager);
                    break;
                default:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
            }
        }
    }

    public void CheckAndShowMatches(UserManager userManager, SelectedUser selectedUser, OperationManager opManager)
    {
        if (selectedUser.GetPatient1() != null)
        {
            UserParent.ResetCounter();
            opManager.ShowPotentialMatches(userManager, selectedUser, opManager);
        }
        else
        {
            Console.WriteLine("NO PATIENT SELECTED\n");
        }
    }

    public void SelectPatientsAndDoctorMenu(UserManager userManager, SelectedUser selectedUser, OperationManager opManager)
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("1.Select patient for operation\n2.Select second patient.\n3.Select doctor to for operation\n4.Let the operation begin.\n5.See operation1 information\n6.Return to Main Menu");
            var choice = Console.ReadKey(true).KeyChar;
            switch (choice)
            {
                case '1':
                case '2':
                    Console.Clear();
                    userManager.SelectPatient(choice, selectedUser, opManager, userManager);
                    break;
                case '3':
                    Console.Clear();
                    userManager.SelectDoctor(choice, selectedUser,opManager, userManager);
                    break;
                case '4':
                    Console.Clear();
                    opManager.DoOperation(selectedUser);
                    break;
                case '5':
                    Console.Clear();
                    userManager.ShowAllSelectedUsers(selectedUser);
                    break;
                    default:
                        isRunning = false;
                        break;
                
            }
            
        }
    }
}