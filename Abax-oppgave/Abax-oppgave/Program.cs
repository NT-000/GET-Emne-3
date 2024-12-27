
using Abax_oppgave;

var menu = new ActionMenu();
var vManager = new VehicleManager();

Run();

void Run()
{
    menu.StartMenu(vManager);
}