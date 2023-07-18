namespace MyContacts.Views;
using MyContacts.Models;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();

		List<Contact> contacts = ContactRepository.GetContacts();
		contactsList.ItemsSource = contacts;
	}

    async void contactsList_ItemSelected(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
    {
		if (contactsList.SelectedItem != null)
		{
			//Logic
			await Shell.Current.GoToAsync(nameof(EditContactsPage));

        }

    }

    void contactsList_ItemTapped(System.Object sender, Microsoft.Maui.Controls.ItemTappedEventArgs e)
    {
        //Deselect item
		//Best to deselect in this event handler
        contactsList.SelectedItem = null;
    }
}
