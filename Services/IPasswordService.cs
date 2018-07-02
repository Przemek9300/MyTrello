using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trelloApi.Services
{
    interface IPasswordService
    {
        string GetHash(string password, string salt);
        string GetSalt();
    }
}
