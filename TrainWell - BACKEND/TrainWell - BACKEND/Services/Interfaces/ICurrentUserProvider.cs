namespace TrainWell___BACKEND.Services.Interfaces
{
    public interface ICurrentUserProvider
    {
        Task<int> GetUserIdAsync();
    }
}