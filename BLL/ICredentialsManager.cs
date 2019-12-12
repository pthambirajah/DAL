using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    interface ICredentialsManager
    {
        ICredentialsDB CredentialsDB { get; }

        Credentials AddCredentials(Credentials credentials);
        
        Credentials UpdateCredentials(Credentials credentials);
        Credentials DeleteCredentials(int id);

        Credentials GetIdCredentials(string username);
        Credentials GetPassword(int idCredentials, string username);

        Credentials isAdmin(string username);
        Credentials isStaff(string username);
        Credentials GetIdStaff(string username);

    }
}
