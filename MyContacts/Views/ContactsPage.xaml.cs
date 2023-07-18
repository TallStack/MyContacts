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
        //Updates list view on previous screen
        ObservableCollection<Contact> contacts = new ObservableCollection<Contact>(ContactRepository.GetContacts());
        contactsList.ItemsSource = contacts;
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
}
