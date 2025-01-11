
using System.Text;
using ST_Tes;

var actionManager = new ActionManager();
var menu = new Menu();
var user = new User("Nico");
Run();

void Run()
{
    menu.StartMenu(actionManager, user);
}