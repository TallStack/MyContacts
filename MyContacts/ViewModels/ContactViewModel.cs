using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyContacts.UseCases;
using MyContacts.UseCases.Interfaces;
using MyContacts.Views_MVVM;
using Contact = MyContacts.CoreBusiness.Contact;
namespace MyContacts.ViewModels
{
	public partial class ContactViewModel : ObservableObject
	{
		public ContactViewModel(IViewContactsUseCases viewContactsUseCases,
			IDeleteContactUseCase deleteContactUseCase)
		{
            this.viewContactsUseCases = viewContactsUseCases;
            this.deleteContactUseCase = deleteContactUseCase;
            this.Contacts = new ObservableCollection<Contact>();
        }

		private readonly IViewContactsUseCases viewContactsUseCases;
        private readonly IDeleteContactUseCase deleteContactUseCase;

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
		[RelayCommand]
        public async Task DeleteContact(int contactId)
        {
			await deleteContactUseCase.ExecuteAsync(contactId);
			await LoadContactsAsync();
        }

        [RelayCommand]
        public async Task GoToEditContact(int contactId)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContact_MVVM_Page)}?Id={contactId}");

        }
    }
}

