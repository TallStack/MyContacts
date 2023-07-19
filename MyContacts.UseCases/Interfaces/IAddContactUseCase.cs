namespace MyContacts.UseCases
{
    public interface IAddContactUseCase
    {
        Task ExecuteAsync(CoreBusiness.Contact contact);
    }
}