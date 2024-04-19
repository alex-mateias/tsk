using tsk.Domain.Models;

namespace tsk.Domain.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByUsernameAsync(string username);
    }
}