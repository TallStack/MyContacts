using System;
using MyContacts.UseCases.PluginInterfaces;

namespace MyContacts.UseCases
{
    public class DeleteContactUseCase : IDeleteContactUseCase
    {
        private readonly IContactRepository contactRepository;

        public DeleteContactUseCase(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        public async Task ExecuteAsync(int contactId)
        {
            await this.contactRepository.DeleteContactAsync(contactId);
        }
    }
}

