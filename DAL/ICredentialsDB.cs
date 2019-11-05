using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DTO;

namespace DAL
{
    public interface ICredentialsDB
    {
        IConfiguration Configuration { get; }
        Credentials AddCredentials(Credentials credentials);
        int DeleteCredentials(int id);
        Credentials GetCredentials (int id);
        int UpdateCredentials(Credentials credentials);
    }
}
