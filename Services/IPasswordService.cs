using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trelloApi.Services
{
    public interface IPasswordService
    {
        string GetHash(string password, string salt);
        string GetSalt();

        
    }
}
