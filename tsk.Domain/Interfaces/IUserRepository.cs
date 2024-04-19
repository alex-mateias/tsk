using tsk.Domain.Models;

namespace tsk.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAsync(string username);
    }
}