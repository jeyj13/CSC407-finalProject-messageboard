using CSC407_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC407_Final.Services
{
    interface IUserServices
    {
        bool Authenticate(string username, string password);

        void Register(User user);
        void Delete(User user);

        bool Exists(string username);

        void ToAdmin(User user);

        List<User> GetUsers();

        void EnableAdmin(string username);

        void FromAdmin(User user);
    }
}
