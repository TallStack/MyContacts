using MyContacts.Views;
using MyContacts.Views_MVVM;

namespace MyContacts;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(ContactsPage), typeof(ContactsPage));
        Routing.RegisterRoute(nameof(AddContactsPage), typeof(AddContactsPage));
        Routing.RegisterRoute(nameof(EditContactsPage), typeof(EditContactsPage));

        Routing.RegisterRoute(nameof(Contacts_MVVM_Page), typeof(Contacts_MVVM_Page));
        Routing.RegisterRoute(nameof(EditContact_MVVM_Page), typeof(EditContact_MVVM_Page));
        Routing.RegisterRoute(nameof(AddContact_MVVM_Page), typeof(AddContact_MVVM_Page));
    }
}

