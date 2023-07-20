using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MyContacts.UseCases.Interfaces;
using Contact = MyContacts.CoreBusiness.Contact;
namespace MyContacts.ViewModels
{
	public class ContactViewModel : ObservableObject
	{
		public ContactViewModel(IViewContactsUseCases viewContactsUseCases)
		{
            this.viewContactsUseCases = viewContactsUseCases;
			this.Contacts = new ObservableCollection<Contact>();
        }

		private readonly IViewContactsUseCases viewContactsUseCases;
		public ObservableCollection<Contact> Contacts { get; set; }

		public async Task LoadContactsAsync()
		{
			this.Contacts.Clear();
			var contacts = await viewContactsUseCases.ExecuteAsync(null);
			if (contacts != null && contacts.Count > 0)
			{
				foreach (var contact in contacts)
				{
                    this.Contacts.Add(contact);
                }
					
			}
		}
    }
}

