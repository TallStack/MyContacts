namespace MyContacts.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();
	}

    void addContactButton_Clicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactsPage));
    }

    void editContactButton_Clicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(EditContactsPage));
    }
}
