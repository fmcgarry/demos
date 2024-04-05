namespace Core
{
    public interface IAnimalFactService
    {
        Task<string> GetRandomCatFactAsync();
    }
}