using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DAL;
using DTO;

namespace BLL
{
    public class CredentialsManager
    {
        private CredentialsDB CredentialsDb { get; }

       
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

        public int GetIdCredentials(string username)
        {
            return CredentialsDb.GetIdCredentials(username);
        }

        public string GetPassword(string username)
        {
            return CredentialsDb.GetPassword(username);
        }

        public int GetStatus(string username)
        {
            return CredentialsDb.GetStatus(username);
        }

        public int GetIdStaff(string username)
        {
            return CredentialsDb.GetIdStaff(username);
        }


    }
}
