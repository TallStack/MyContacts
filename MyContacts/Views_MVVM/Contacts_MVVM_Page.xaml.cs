using MyContacts.ViewModels;

namespace MyContacts.Views_MVVM;

public partial class Contacts_MVVM_Page : ContentPage
{
    private readonly ContactViewModel contactViewModel;

    public Contacts_MVVM_Page(ContactViewModel contactViewModel)
	{
		InitializeComponent();
        this.contactViewModel = contactViewModel;
        this.BindingContext = contactViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await this.contactViewModel.LoadContactsAsync();
    }
}
