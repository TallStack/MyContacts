namespace MyContacts.UseCases
{
    public interface IDeleteContactUseCase
    {
        Task ExecuteAsync(int contactId);
    }
}