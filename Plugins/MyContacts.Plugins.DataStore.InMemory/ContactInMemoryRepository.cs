using MyContacts.UseCases.PluginInterfaces;
using MyContacts.CoreBusiness;

namespace MyContacts.Plugins.DataStore.InMemory;

// All the code in this file is included in all platforms.
public class ContactInMemoryRepository : IContactRepository
{
    static List<CoreBusiness.Contact> contacts;

   // public static List<CoreBusiness.Contact> GetContacts() => contacts;

    public ContactInMemoryRepository()
    {
        contacts = new List<CoreBusiness.Contact>() { new CoreBusiness.Contact { contactId = 1, name = "test", number = "0825547766" },
        new CoreBusiness.Contact { contactId = 2, name = "test1", number = "0825547766" },
        new CoreBusiness.Contact { contactId = 3, name = "test2", number = "0825547766" }};
    }

    public Task AddContactAsync(CoreBusiness.Contact contact)
    {
        int maxId = 0;
        if (contacts.Count > 0)
        {
            maxId = contacts.Max(x => x.contactId);
            contact.contactId = maxId + 1;
        }
        else
        {
            contact.contactId = 1;
        }
        contacts.Add(contact);
        return Task.CompletedTask;
    }

    public Task DeleteContactAsync(int contactId)
    {
        var contact = contacts.FirstOrDefault(x => x.contactId == contactId);
        if (contact != null)
        {
            contacts.Remove(contact);
        }
        return Task.CompletedTask;
    }

    public Task<CoreBusiness.Contact> GetContactByIdAsync(int contactId)
    {
        var contact = contacts.FirstOrDefault(x => x.contactId == contactId);
        if (contact != null)
        {
            return Task.FromResult(new CoreBusiness.Contact
            {
                contactId = contact.contactId,
                address = contact.address,
                name = contact.name,
                email = contact.email,
                number = contact.number
            });
        }
        return null;
    }

    public Task<List<CoreBusiness.Contact>> GetContactsAsync(string searchText)
    {
        if(string.IsNullOrWhiteSpace(searchText))
        {
            return Task.FromResult(contacts);
        }
        var filteredContacts = contacts.Where(x => !string.IsNullOrWhiteSpace(x.name) && x.name.StartsWith(searchText, StringComparison.OrdinalIgnoreCase))?.ToList();
        return Task.FromResult(filteredContacts);
    }

    public Task UpdateContactAsync(int contactId, CoreBusiness.Contact contact)
    {
        if (contactId != contact.contactId)
            return Task.CompletedTask;
        var updatedContact = contacts.FirstOrDefault(x => x.contactId == contactId);
        if (updatedContact != null)
        {
            //AutoMapper
            updatedContact.name = contact.name;
            updatedContact.number = contact.number;
            updatedContact.address = contact.address;
            updatedContact.email = contact.email;
        }
        return Task.CompletedTask;
    }
}

