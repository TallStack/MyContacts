using System.Runtime.CompilerServices;
using MyContacts.ViewModels;

namespace MyContacts.Views_MVVM.Controls_MVVM;

public partial class ContactControl_MVVM : ContentView
{
	public bool IsForEdit { get; set; }
	public bool IsForAdd { get; set; }
    public ContactControl_MVVM()
	{
		InitializeComponent();
	}
    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
		if (IsForAdd && !IsForEdit)
		{
            btnSave.SetBinding(Button.CommandProperty, "AddContactCommand");
        }
		else if (IsForEdit && !IsForAdd)
            btnSave.SetBinding(Button.CommandProperty, "EditContactCommand");
    }
}
