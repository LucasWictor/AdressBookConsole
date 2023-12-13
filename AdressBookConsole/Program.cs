using AdressBookConsole.Interfaces;
using AdressBookConsole.Services;

class Program
{
    static void Main()
    {
        AdressBookConsole.Interfaces.IServiceProvider serviceProvider = new ServiceProvider();
        AdressBookConsole.Interfaces.IMenuService menuService = serviceProvider.GetMenuService();
        menuService.ShowMainMenu();
    }
}