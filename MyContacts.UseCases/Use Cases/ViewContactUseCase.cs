using System;
using MyContacts.UseCases.PluginInterfaces;
using Contact = MyContacts.CoreBusiness.Contact;
namespace MyContacts.UseCases
{
    public class ViewContactUseCase : IViewContactUseCase
    {
        public ViewContactUseCase(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public IContactRepository contactRepository;

        public async Task<Contact> ExecuteAsync(int contactId)
        {
            return await this.contactRepository.GetContactByIdAsync(contactId);
        }

    }
}

