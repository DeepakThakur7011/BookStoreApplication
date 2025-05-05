namespace BookStoreApplication.Services
{
    public interface IUserService
    {
        string GetUserId();
        public bool IsAuthenticated();
    }
}