using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DTO;

namespace DAL
{
    public interface ICredentialsDB
    {
        IConfiguration Configuration { get; }
        Credentials AddCredentials(Credentials credentials);
     
        Credentials GetCredentials (int id);

        int getStatus(string username);
      
        string GetPassword(int idCredentials, string username);
        int GetIdStaff(string username);

    }
}
