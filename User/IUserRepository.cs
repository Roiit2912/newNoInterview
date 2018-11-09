using System.Collections.Generic;

namespace sample
{

    public interface IUserRepository
    {
        User GetUser(string Email);

        string Hash(string password);

         void Register(User obj);

         string GenerateSecurityKey(string data);

        
        
    }
}
