using MyContacts.Models;
using MyContacts.UseCases;

namespace MyContacts.Views;

public partial class AddContactsPage : ContentPage
{
    private readonly IAddContactUseCase addContactUseCase;

    public AddContactsPage(IAddContactUseCase addContactUseCase)
	{
		InitializeComponent();
        this.addContactUseCase = addContactUseCase;
    }

    async void contactControl_OnCancel(System.Object sender, System.EventArgs e)
    {
        //Navigating to root/parent page
        await Shell.Current.GoToAsync("..");
    }

    async void contactControl_OnSave(System.Object sender, System.EventArgs e)
    {
        //ContactRepository.AddContact(new Models.Contact
        await addContactUseCase.ExecuteAsync(new CoreBusiness.Contact
        {
            name = contactControl.name,
            email = contactControl.email,
            number = contactControl.number,
            address = contactControl.address
        });
        //Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
        await Shell.Current.GoToAsync("..");
    }

    void contactControl_OnError(System.Object sender, System.String e)
    {
        DisplayAlert("Error", e, "Ok");
    }
}
