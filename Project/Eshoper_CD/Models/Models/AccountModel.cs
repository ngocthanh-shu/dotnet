using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class AccountModel
    {
        private EShoperDbContext context = null;
        public AccountModel()
        {
            context = new EShoperDbContext();
        }

        public bool LoginAsAdminstrator(string username, string password)
        {
            object[] sqlprams =
            {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password),
            };
            var res = context.Database.SqlQuery<Account>("account_login @username, @password", sqlprams).SingleOrDefault();
            if(res != null)
            {
                if(res.adminstrator == true)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Login(string username, string password)
        {
            object[] sqlprams =
            {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password),
            };
            var res = context.Database.SqlQuery<Account>("account_login @username, @password", sqlprams).SingleOrDefault();
            if(res != null)
            {
                if(res.adminstrator == false)
                {
                    return true;
                }
            }
            return false;
        }

        public Account CreateAccount(string username, string password, string lname, string fname, string email)
        {
            object[] sqlprams =
            {
                new SqlParameter("@username",username),
                new SqlParameter("@password",password),
                new SqlParameter("@lname",lname),
                new SqlParameter("@fname",fname),
                new SqlParameter("@email",email),
            };
            var res = context.Database.SqlQuery<Account>("account_createAccount @username,@password,@lname,@fname,@email", sqlprams).SingleOrDefault();
            return res;
        }

        public List<Account> GetAccounts()
        {
            var res = context.Database.SqlQuery<Account>("account_getAccounts").ToList();
            return res;
        }

        public Account GetAccountDetail(string username) 
        {
            object[] sqlprams =
            {
                new SqlParameter("@username",username),
            };
            var res = context.Database.SqlQuery<Account>("account_getAccountDetail @username", sqlprams).SingleOrDefault();
            return res;
        }

        public Account ChangePassword(string username, string password)
        {
            object[] sqlprams =
            {
                new SqlParameter("@username",username),
                new SqlParameter("@password",password),
            };
            var res = context.Database.SqlQuery<Account>("account_updatePassword @username,@password",sqlprams).SingleOrDefault();
            return res;
        }

        public Account DeleteAccount(string username)
        {
            object[] sqlprams =
            {
                new SqlParameter("@username", username),
            };
            var res = context.Database.SqlQuery<Account>("Account_deleteAccount @username", sqlprams).SingleOrDefault();
            return res;
        }
    }
}
