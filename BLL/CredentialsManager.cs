using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DAL;
using DTO;

namespace BLL
{
    public class CredentialsManager
    {
        public CredentialsDB CredentialsDb { get; }


        public CredentialsManager(IConfiguration configuration)
        {
            CredentialsDb = new CredentialsDB(configuration);
        }


        public Credentials GetCredentials(int id)
        {
            return CredentialsDb.GetCredentials(id);
        }

        public Credentials AddCredentials(Credentials credentials)
        {
            return CredentialsDb.AddCredentials(credentials);
        }

        public int UpdateCredentials(Credentials credentials)
        {
            return CredentialsDb.UpdateCredentials(credentials);

        }

        public int DeleteCredentials(int id)
        {
            return CredentialsDb.DeleteCredentials(id);
        }

        /*
        public int GetIdCustomer(string usernameC)
        {
            throw new NotImplementedException();
        }
        */
        public int GetIdCredentials(string username)
        {
            return CredentialsDb.GetIdCredentials(username);
        }

        public string GetPassword(int idCredentials, string username)
        {
            return CredentialsDb.GetPassword(idCredentials, username);
        }

        public bool isAdmin(string username)
        {
            return CredentialsDb.isAdmin(username);
        }

        public int GetIdStaff(string username)
        {
            return CredentialsDb.GetIdStaff(username);
        }

        public bool isStaff(string username)
        {
            return CredentialsDb.isStaff(username);
        }

    }
}
