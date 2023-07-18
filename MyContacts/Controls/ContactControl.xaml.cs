namespace MyContacts.Controls;

public partial class ContactControl : ContentView
{
    //Similar to delegates
    public event EventHandler<string> OnError;
    public event EventHandler<EventArgs> OnSave;
    public event EventHandler<EventArgs> OnCancel;
    public ContactControl()
	{
		InitializeComponent();
	}

	public string name
	{
		get
		{
			return nameEntry.Text;
		}
		set
		{
		   nameEntry.Text = value;
		}
	}
    public string number
    {
        get
        {
            return numberEntry.Text;
        }
        set
        {
            numberEntry.Text = value;
        }
    }
    public string email
    {
        get
        {
            return emailEntry.Text;
        }
        set
        {
            emailEntry.Text = value;
        }
    }
    public string address
    {
        get
        {
            return addressEntry.Text;
        }
        set
        {
            addressEntry.Text = value;
        }
    }

    void btnSave_Clicked(System.Object sender, System.EventArgs e)
    {
        if (nameValidator.IsNotValid)
        {
            OnError?.Invoke(sender, "Name is required");
            return;
        }
        if (emailValidator.IsNotValid)
        {
            foreach (var error in emailValidator.Errors)
            {
                OnError?.Invoke(sender, error.ToString());
                return;
            }
        }
        OnSave?.Invoke(sender, e);
    }

    void backBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        OnCancel?.Invoke(sender, e);
    }
}
