namespace AdressBookConsole.Interfaces
{
    public interface IServiceProvider
    {
        IMenuService GetMenuService();
        IContactRepository GetContactRepository();
        IFileService GetFileService();
    }
}
