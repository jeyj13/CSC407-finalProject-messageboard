﻿using CSC407_Final.Data;
using CSC407_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSC407_Final.Services;
using System.Web.Security;

namespace CSC407_Final.Services
{
    public class UserService : IUserServices
    {

        private FinalDbContext context;

        private IEncryptor encryptor;
                    public UserService()
            {
                this.context = new FinalDbContext();
            }
//************************************************************************************************************************
        public UserService(IEncryptor encryptor)
        {
            this.encryptor = encryptor;

            this.context = new FinalDbContext();
        }


//************************************************************************************************************************
        public bool Authenticate(string username, string password)
        {
            string encryptedPassword = this.encryptor.Encrypt(password);

            User user = this.context.Users.Where(x => x.Username == username && x.Password == encryptedPassword).SingleOrDefault();

            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }


        }

//***************************************************************************************************************************
        public void Register(Models.User user)
        {
            user.Password = this.encryptor.Encrypt(user.Password);

            user.Admin = false;

            this.context.Users.Add(user);

            this.context.SaveChanges();
        }

//***************************************************************************************************************************
        public bool Exists(string username)
        {
            User user = this.context.Users.Where(x => x.Username.ToLower() == username.ToLower()).SingleOrDefault();

            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
//***************************************************************************************************************************
        public void ToAdmin(Models.User user)
        {
            user.Admin = true;
            this.context.Users.Add(user);
            this.context.SaveChanges();
        }
        //************************************************************************************************************************
        public List<User> GetUsers()
        {
            var users = this.context.Users.ToList();

            return this.context.Users.ToList();
        }
        //******************************************************************************************************************************************
        public void EnableAdmin(string username)
        {
            User user =  this.context.Users.Where(x => x.Username == username).SingleOrDefault();
            if (!Roles.RoleExists("administrator"))
                Roles.CreateRole("administrator");

                            if(user.Admin == true && Roles.IsUserInRole(user.Username,"administrator") != true)
                {
                                Roles.AddUserToRole(user.Username, "administrator");
                }
                            else
                            {
                                
                            }
                
        }
        //************************************************************************************************************************
        public void FromAdmin(Models.User user)
        {
            user.Admin = false;
            this.context.Users.Add(user);
            this.context.SaveChanges();
        }
        //************************************************************************************************************************
    }
}