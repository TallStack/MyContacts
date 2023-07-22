using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MyContacts.Plugins.DataStore.InMemory;
using MyContacts.UseCases;
using MyContacts.UseCases.Interfaces;
using MyContacts.UseCases.PluginInterfaces;
using MyContacts.ViewModels;
using MyContacts.Views;
using MyContacts.Views_MVVM;

namespace MyContacts;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		// Use Case Dependency Injection
		builder.Services.AddSingleton<IContactRepository, ContactInMemoryRepository>();
        builder.Services.AddSingleton<IViewContactsUseCases, ViewContactsUseCases>();
        builder.Services.AddSingleton<IViewContactUseCase, ViewContactUseCase>();
        builder.Services.AddTransient<IEditContactUseCase, EditContactUseCase>();
        builder.Services.AddTransient<IAddContactUseCase, AddContactUseCase>();
        builder.Services.AddTransient<IDeleteContactUseCase, DeleteContactUseCase>();

		//Event driven/Use Case View Dependency injection
        builder.Services.AddSingleton<ContactsPage>();
        builder.Services.AddSingleton<EditContactsPage>();
        builder.Services.AddSingleton<AddContactsPage>();

		//ViewModels dependency injection
		builder.Services.AddSingleton<ContactViewModel>();
        builder.Services.AddSingleton<ContactsViewModel>();

        //ViewModel views dependency injection
        builder.Services.AddSingleton<Contacts_MVVM_Page>();
        builder.Services.AddSingleton<EditContact_MVVM_Page>();
        builder.Services.AddSingleton<AddContact_MVVM_Page>();
        return builder.Build();
	}
}

