using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DTO;

namespace DAL
{
    public interface ICredentialsDB
    {
        Credentials AddCredentials(Credentials credentials);
     
        Credentials GetCredentials (int id);

        int GetStatus(string username);
      
        string GetPassword(string username);
        int GetIdStaff(string username);

    }
}
