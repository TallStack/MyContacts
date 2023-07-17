using MyContacts.Views;

namespace MyContacts;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(ContactsPage), typeof(ContactsPage));
        Routing.RegisterRoute(nameof(AddContactsPage), typeof(AddContactsPage));
        Routing.RegisterRoute(nameof(EditContactsPage), typeof(EditContactsPage));
    }
}

