using MyContacts.CoreBusiness;
using MyContacts.UseCases.PluginInterfaces;

namespace MyContacts.UseCases;

// All the code in this file is included in all platforms.
public class ViewContactsUseCases
{
    private readonly IContactRepository contactRepository;
    public ViewContactsUseCases(IContactRepository contactRepository)
    {
        this.contactRepository = contactRepository;
    }
    public async Task<List<CoreBusiness.Contact>> ExecuteAsync(string searchText)
    {
        return await this.contactRepository.GetContactsAsync(searchText);
    }
}

