using tsk.Domain.Interfaces;
using tsk.Domain.Models;

namespace tsk.DataAccess
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public Task<User> GetUserByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}