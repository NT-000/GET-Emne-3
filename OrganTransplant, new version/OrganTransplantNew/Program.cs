
using OrganTransplantNew;

var startMenu = new StartMenu();
var userManager = new UserManager();
var selectedUsers = new SelectedUser();
var opManager = new OperationManager();

Run();

void Run()
{
    startMenu.Start(userManager, selectedUsers, opManager);
}