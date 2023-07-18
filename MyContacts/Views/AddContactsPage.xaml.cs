using MyContacts.Models;
namespace MyContacts.Views;

public partial class AddContactsPage : ContentPage
{
	public AddContactsPage()
	{
		InitializeComponent();
	}

    void contactControl_OnCancel(System.Object sender, System.EventArgs e)
    {
        //Navigating to root/parent page
        Shell.Current.GoToAsync("..");
    }

    void contactControl_OnSave(System.Object sender, System.EventArgs e)
    {
        ContactRepository.AddContact(new Models.Contact
        {
            name = contactControl.name,
            email = contactControl.email,
            number = contactControl.number,
            address = contactControl.address
        });
        //Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
        Shell.Current.GoToAsync("..");
    }

    void contactControl_OnError(System.Object sender, System.String e)
    {
        DisplayAlert("Error", e, "Ok");
    }
}
