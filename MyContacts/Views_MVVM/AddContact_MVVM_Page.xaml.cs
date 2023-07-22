using MyContacts.ViewModels;

namespace MyContacts.Views_MVVM;

public partial class AddContact_MVVM_Page : ContentPage
{
    private readonly ContactsViewModel contactsViewModel;

    public AddContact_MVVM_Page(ContactsViewModel contactsViewModel)
	{
		InitializeComponent();
        this.contactsViewModel = contactsViewModel;
        
        this.BindingContext = this.contactsViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        this.contactsViewModel.Contact = new CoreBusiness.Contact();
    }
}
