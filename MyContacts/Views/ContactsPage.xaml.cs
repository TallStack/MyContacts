namespace MyContacts.Views;

using System.Collections.ObjectModel;
using MyContacts.Models;
using MyContacts.UseCases;
using MyContacts.UseCases.Interfaces;

public partial class ContactsPage : ContentPage
{
    private readonly IDeleteContactUseCase deleteContactUseCase;

    public IViewContactsUseCases ViewContactsUseCases { get; }

    public ContactsPage(IViewContactsUseCases viewContactsUseCases, IDeleteContactUseCase deleteContactUseCase)
	{
		InitializeComponent();
        ViewContactsUseCases = viewContactsUseCases;
        this.deleteContactUseCase = deleteContactUseCase;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        searchEntry.Text = string.Empty;
        loadContacts();
    }

    async void contactsList_ItemSelected(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
    {
		if (contactsList.SelectedItem != null)
		{
			//Logic
			await Shell.Current.GoToAsync($"{nameof(EditContactsPage)}?Id={((CoreBusiness.Contact)contactsList.SelectedItem).contactId}");

        }

    }

    void contactsList_ItemTapped(System.Object sender, Microsoft.Maui.Controls.ItemTappedEventArgs e)
    {
        //Deselect item
		//Best to deselect in this event handler
        contactsList.SelectedItem = null;
    }

    void addContactBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactsPage));
    }

    async void deleteBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem.CommandParameter as CoreBusiness.Contact;
        //ContactRepository.DeleteContact(contact.contactId);
        await deleteContactUseCase.ExecuteAsync(contact.contactId);
        loadContacts();
    }

    private async void loadContacts()
    {
        //Updates list view on previous screen
        ObservableCollection<CoreBusiness.Contact> contacts = new ObservableCollection<CoreBusiness.Contact>(await this.ViewContactsUseCases.ExecuteAsync(""));
        contactsList.ItemsSource = contacts;
    }

    async void searchEntry_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        //var contacts = new ObservableCollection<Contact>(ContactRepository.SearchContacts(searchEntry.Text));
        ObservableCollection<CoreBusiness.Contact> contacts = new ObservableCollection<CoreBusiness.Contact>(await this.ViewContactsUseCases.ExecuteAsync(searchEntry.Text));
        contactsList.ItemsSource = contacts;
    }
}
