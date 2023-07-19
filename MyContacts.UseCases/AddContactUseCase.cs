using System;
using MyContacts.UseCases.PluginInterfaces;

namespace MyContacts.UseCases
{
    public class AddContactUseCase : IAddContactUseCase
    {
        private readonly IContactRepository contactRepository;

        public AddContactUseCase(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        public async Task ExecuteAsync(CoreBusiness.Contact contact)
        {
            await this.contactRepository.AddContactAsync(contact);
        }
    }
}

