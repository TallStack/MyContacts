using System;
using System.Collections.ObjectModel;
using MyContacts.UseCases.Interfaces;
using Contact = MyContacts.CoreBusiness.Contact;
namespace MyContacts.ViewModels
{
	public class ContactViewModel
	{
		public ContactViewModel(IViewContactsUseCases viewContactsUseCases)
		{
            this.viewContactsUseCases = viewContactsUseCases;
			this.contacts = new ObservableCollection<Contact>();
        }

		private readonly IViewContactsUseCases viewContactsUseCases;
		public ObservableCollection<Contact> contacts;

		public async Task LoadContacts(string searchText)
		{
			this.contacts.Clear();
			var Contacts = await viewContactsUseCases.ExecuteAsync(null);
			if (Contacts != null && Contacts.Count > 0)
			{
				foreach (var contact in Contacts)
					contacts.Add(contact);
			}
		}
    }
}

