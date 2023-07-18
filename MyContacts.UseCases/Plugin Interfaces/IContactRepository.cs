using System;
namespace MyContacts.UseCases.PluginInterfaces
{
	public interface IContactRepository
	{
        Task<List<CoreBusiness.Contact>> GetContactsAsync(string searchText);

    }
}

