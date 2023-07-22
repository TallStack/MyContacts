using MyContacts.ViewModels;

namespace MyContacts.Views_MVVM;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContact_MVVM_Page : ContentPage
{
    private readonly ContactsViewModel contactsViewModel;

    public EditContact_MVVM_Page(ContactsViewModel contactsViewModel)
	{
		InitializeComponent();
        this.contactsViewModel = contactsViewModel;
        this.BindingContext = contactsViewModel;
    }

    public string ContactId
    {
        set
        {
            if (!string.IsNullOrWhiteSpace(value) && int.TryParse(value, out int contactId))
            {
                LoadContact(contactId);
            }
        }
    }

    private async void LoadContact(int contactId)
    {
        await this.contactsViewModel.LoadContact(contactId);
    }
}
