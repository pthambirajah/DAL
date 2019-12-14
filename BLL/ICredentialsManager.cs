using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    interface ICredentialsManager
    {
        Credentials AddCredentials(Credentials credentials);
       
        Credentials GetIdCredentials(string username);
        Credentials GetPassword(int idCredentials, string username);

        int getStatus(string username);
 
        Credentials GetIdStaff(string username);

    }
}
