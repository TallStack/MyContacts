namespace MyContacts.Views;

public partial class AddContactsPage : ContentPage
{
	public AddContactsPage()
	{
		InitializeComponent();
	}

    void backBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}
