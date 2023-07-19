using System;
using MyContacts.UseCases.PluginInterfaces;

namespace MyContacts.UseCases
{
    public class EditContactUseCase : IEditContactUseCase
    {
        private readonly IContactRepository contactRepository;

        public EditContactUseCase(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        public async Task ExecuteAsync(int contactId, CoreBusiness.Contact contact)
        {
            await this.contactRepository.UpdateContactAsync(contactId, contact);
        }
    }
}

