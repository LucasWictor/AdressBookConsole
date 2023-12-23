namespace SharedCode
{
    public interface IServiceProvider
    {
        
        IContactRepository GetContactRepository();
        IFileService GetFileService();
    }
}