namespace MyContacts.UseCases
{
    public interface IEditContactUseCase
    {
        Task ExecuteAsync(int contactId, CoreBusiness.Contact contact);
    }
}