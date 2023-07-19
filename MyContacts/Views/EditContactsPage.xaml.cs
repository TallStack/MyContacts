namespace MyContacts.Views;
using MyContacts.Models;
using MyContacts.UseCases;

[QueryProperty(nameof(ContactId),"Id")]
public partial class EditContactsPage : ContentPage
{
    public IEditContactUseCase editContactUseCase { get; }
    public IViewContactUseCase viewContactUseCase { get; }

    private CoreBusiness.Contact contact;
	public EditContactsPage(IEditContactUseCase editContactUseCase, IViewContactUseCase viewContactUseCase)
	{
		InitializeComponent();
        this.editContactUseCase = editContactUseCase;
        this.viewContactUseCase = viewContactUseCase;
    }

	public string ContactId
	{
		set
		{
            //contact = ContactRepository.GetContact(Convert.ToInt32(value));
            contact = viewContactUseCase.ExecuteAsync(Convert.ToInt32(value)).GetAwaiter().GetResult();
            if (contact != null)
			{
                contactControl.name = contact.name;
                contactControl.number = contact.number;
                contactControl.email = contact.email;
                contactControl.address = contact.address;
            }
			
		}
	}

    

    private async void contactControl_OnSave(System.Object sender, System.EventArgs e)
    {
        contact.name = contactControl.name;
        contact.number = contactControl.number;
        contact.email = contactControl.email;
        contact.address = contactControl.address;

        //ContactRepository.UpdateContact(contact.contactId, contact);
        await editContactUseCase.ExecuteAsync(contact.contactId, contact);
        await Shell.Current.GoToAsync("..");
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
