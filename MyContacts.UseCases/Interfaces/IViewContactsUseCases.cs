using System;
namespace MyContacts.UseCases.Interfaces
{
	public interface IViewContactsUseCases
	{
        Task<List<CoreBusiness.Contact>> ExecuteAsync(string searchText);
    }
}

