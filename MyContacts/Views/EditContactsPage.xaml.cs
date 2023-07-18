namespace MyContacts.Views;
using MyContacts.Models;
[QueryProperty(nameof(ContactId),"Id")]
public partial class EditContactsPage : ContentPage
{
	private Contact contact;
	public EditContactsPage()
	{
		InitializeComponent();
	}

	public string ContactId
	{
		set
		{
			contact = ContactRepository.GetContact(Convert.ToInt32(value));
			if (contact != null)
			{
                contactControl.name = contact.name;
                contactControl.number = contact.number;
                contactControl.email = contact.email;
                contactControl.address = contact.address;
            }
			
		}
	}

    private void contactControl_OnSave(System.Object sender, System.EventArgs e)
    {
        contact.name = contactControl.name;
        contact.number = contactControl.number;
        contact.email = contactControl.email;
        contact.address = contactControl.address;

        ContactRepository.UpdateContact(contact.contactId, contact);
        Shell.Current.GoToAsync("..");
    }

    private void contactControl_OnCancel(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    private void contactControl_OnError(System.Object sender, System.String e)
    {
        DisplayAlert("Error", e, "OK");
    }
}
