using AdressBookConsole.Interfaces;

namespace AdressBookConsole.Services
{
    public class ServiceProvider : Interfaces.IServiceProvider
    {
        public IMenuService GetMenuService()
        {
            return new MenuService(GetContactRepository());
        }

        public IContactRepository GetContactRepository()
        {
            return new ContactRepository(GetFileService());
        }

        public IFileService GetFileService()
        {
            return new FileService(@"C:\Projects\content.json");
        }
    }
}
