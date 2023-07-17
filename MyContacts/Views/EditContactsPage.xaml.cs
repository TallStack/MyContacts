namespace MyContacts.Views;

public partial class EditContactsPage : ContentPage
{
	public EditContactsPage()
	{
		InitializeComponent();
	}

    void backBtn_Clicked(System.Object sender, System.EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }
}
