
namespace InterfacesSharedCode.interfaces
{
    public interface IServiceProvider
    {
        IMenuService GetMenuService();
        IContactRepository GetContactRepository();
        IFileService GetFileService();
    }
}