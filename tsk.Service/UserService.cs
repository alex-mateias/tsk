using tsk.Domain.Interfaces;
using tsk.Domain.Models;

namespace tsk.Service
{
    public class UserService : Service<User>, IUserService
    {
        public Task<User> GetUserByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}