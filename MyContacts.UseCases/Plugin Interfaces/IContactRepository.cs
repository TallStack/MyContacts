using System;

namespace MyContacts.UseCases.PluginInterfaces
{
	public interface IContactRepository
	{
        Task AddContactAsync(CoreBusiness.Contact contact);
        Task DeleteContactAsync(int contactId);
        Task<CoreBusiness.Contact> GetContactByIdAsync(int contactId);
        Task<List<CoreBusiness.Contact>> GetContactsAsync(string searchText);
        Task UpdateContactAsync(int contactId, CoreBusiness.Contact contact);
    }
}

