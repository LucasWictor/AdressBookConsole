using SharedCode;

namespace SharedCode
{ 
public class ServiceProvider : SharedCode.IServiceProvider
{
    private readonly IFileService _fileService;

    public ServiceProvider(IFileService fileService)
    {
        _fileService = fileService;
    }

    public IContactRepository GetContactRepository()
    {
        return new ContactRepository(_fileService);
    }

    public IFileService GetFileService()
    {
        return _fileService;
    }
}
}