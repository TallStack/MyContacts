using MyContacts.UseCases.PluginInterfaces;
using SQLite;
namespace MyContacts.DataStore.SQLLite;

// All the code in this file is included in all platforms.
public class ContactSQLiteRepository : IContactRepository
{
    private SQLiteAsyncConnection database;
    public ContactSQLiteRepository()
    {
        this.database = new SQLiteAsyncConnection(Constants.databasePath);
        this.database.CreateTableAsync<CoreBusiness.Contact>();
    }
    public async Task AddContactAsync(CoreBusiness.Contact contact)
    {
        await this.database.InsertAsync(contact);
    }

    public async Task DeleteContactAsync(int contactId)
    {
        var contact = await GetContactByIdAsync(contactId);
        if (contact != null && contact.contactId == contactId)
        {
            await this.database.DeleteAsync(contact);
        }
       
    }

    public async Task<CoreBusiness.Contact> GetContactByIdAsync(int contactId)
    {
        return await this.database.Table<CoreBusiness.Contact>().Where(x => x.contactId == contactId).FirstOrDefaultAsync();
    }

    public async Task<List<CoreBusiness.Contact>> GetContactsAsync(string searchText)
    {
        if (string.IsNullOrWhiteSpace(searchText))
        {
            return await this.database.Table<CoreBusiness.Contact>().ToListAsync();
        }else
        {
            return await this.database.Table<CoreBusiness.Contact>().Where(x => x.name.Contains(searchText) || x.number.Contains(searchText)).ToListAsync();
            //return await this.database.QueryAsync<Contact>(@"
            //    SELECT *
            //    FROM Contact
            //    WHERE 
            //        Name LIKE ? OR
            //        Email LIKE ? OR
            //        Phone LIKE ? OR
            //        Address LIKE ?",
            //       $"{searchText}%",
            //       $"{searchText}%",
            //       $"{searchText}%",
            //       $"{searchText}%");
        }
    }

    public async Task UpdateContactAsync(int contactId, CoreBusiness.Contact contact)
    {
        if (contactId == contact.contactId)
        {
            await this.database.UpdateAsync(contact);
        }
       
    }
}

