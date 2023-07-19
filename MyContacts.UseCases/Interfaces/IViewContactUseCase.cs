namespace MyContacts.UseCases
{
    public interface IViewContactUseCase
    {
        Task<CoreBusiness.Contact> ExecuteAsync(int contactId);
    }
}