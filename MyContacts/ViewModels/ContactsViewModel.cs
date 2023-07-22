
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyContacts.Models;
using MyContacts.Views_MVVM;
using MyContacts.UseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Contact = MyContacts.CoreBusiness.Contact;
using MyContacts.UseCases;

namespace MyContacts.ViewModels
{
	public partial class ContactsViewModel : ObservableObject
    {
        private readonly IViewContactUseCase viewContactUseCase;
        private readonly IEditContactUseCase editContactUseCase;

        public ContactsViewModel(IViewContactUseCase viewContactUseCase,
            IEditContactUseCase editContactUseCase, IAddContactUseCase addContactUseCase)
		{
            this.Contact = new Contact();
            this.viewContactUseCase = viewContactUseCase;
            this.editContactUseCase = editContactUseCase;
            this.addContactUseCase = addContactUseCase;
        }
        private Contact contact;

        public Contact Contact
        {
            get => contact;
            set
            {
                SetProperty(ref contact, value);
            }
        }

        public IAddContactUseCase addContactUseCase { get; }

        public async Task LoadContact(int contactId)
        {
            this.Contact = await this.viewContactUseCase.ExecuteAsync(contactId);
        }

        [RelayCommand]
        public async Task EditContact()
        {
            await this.editContactUseCase.ExecuteAsync(this.contact.contactId, this.contact);
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public async Task GoToContacts()
        {
            await Shell.Current.GoToAsync("..");

        }

        [RelayCommand]
        public async Task AddContact()
        {
            await this.addContactUseCase.ExecuteAsync(this.contact);
            await Shell.Current.GoToAsync("..");
        }
    }
}

