using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MyContacts.Plugins.DataStore.InMemory;
using MyContacts.UseCases;
using MyContacts.UseCases.Interfaces;
using MyContacts.UseCases.PluginInterfaces;
using MyContacts.Views;

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

		builder.Services.AddSingleton<IContactRepository, ContactInMemoryRepository>();
        builder.Services.AddSingleton<IViewContactsUseCases, ViewContactsUseCases>();
        builder.Services.AddSingleton<IViewContactUseCase, ViewContactUseCase>();
        builder.Services.AddTransient<IEditContactUseCase, EditContactUseCase>();
        builder.Services.AddTransient<IAddContactUseCase, AddContactUseCase>();
        builder.Services.AddTransient<IDeleteContactUseCase, DeleteContactUseCase>();

        builder.Services.AddSingleton<ContactsPage>();
        builder.Services.AddSingleton<EditContactsPage>();
        builder.Services.AddSingleton<AddContactsPage>();

        return builder.Build();
	}
}

