namespace WebApplication7.Services
{
    public interface IUserService
    {
        string GetUserId();
        public bool IsAuthenticated();
    }
}