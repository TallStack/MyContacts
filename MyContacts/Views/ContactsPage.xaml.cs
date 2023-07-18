namespace MyContacts.Views;

using System.Collections.ObjectModel;
using MyContacts.Models;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();
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
			await Shell.Current.GoToAsync($"{nameof(EditContactsPage)}?Id={((Contact)contactsList.SelectedItem).contactId}");

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

    void deleteBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem.CommandParameter as Contact;
        ContactRepository.DeleteContact(contact.contactId);
        loadContacts();
    }

    private void loadContacts()
    {
        //Updates list view on previous screen
        ObservableCollection<Contact> contacts = new ObservableCollection<Contact>(ContactRepository.GetContacts());
        contactsList.ItemsSource = contacts;
    }

    void searchEntry_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        var contacts = new ObservableCollection<Contact>(ContactRepository.SearchContacts(searchEntry.Text));
        contactsList.ItemsSource = contacts;
    }
}
