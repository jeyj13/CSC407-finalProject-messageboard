using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC407_Final.Services
{
    interface IEncryptor
    {
        string Encrypt(string input);
    }
}
