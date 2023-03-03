using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class ProfileModel
    {
        private EShoperDbContext context = null;
        public ProfileModel()
        {
            context = new EShoperDbContext();
        }

        public List<Profile> GetProfiles()
        {
            var res = context.Database.SqlQuery<Profile>("profile_getProfiles").ToList();
            return res;
        }
        public List<Profile> GetAllProfiles()
        {
            var res = context.Database.SqlQuery<Profile>("profile_getAllProfiles").ToList();
            return res;
        }
        public Profile GetProfileDetail(string username)
        {
            object[] sqlParams = {
                new SqlParameter("@username",username),
            };
            var res = context.Database.SqlQuery<Profile>("profile_getProfileDetail @username", sqlParams).SingleOrDefault();
            return res;
        }
        public Profile UpdateProfile(string username, string fname, string lname, DateTime birthday, string phonenumber, string email, string address, string city, string country, string postalcode, string aboutme)
        {
            object[] sqlParams =
            {
                new SqlParameter("@username", username),
                new SqlParameter("@fname", fname),
                new SqlParameter("@lname", lname),
                new SqlParameter("@birthday", birthday),
                new SqlParameter("@phonenumber", phonenumber),
                new SqlParameter("@email", email),
                new SqlParameter("@address", address),
                new SqlParameter("@city", city),
                new SqlParameter("@country", country),
                new SqlParameter("@postalcode", postalcode),
                new SqlParameter("@aboutme", aboutme),

            };
            var res = context.Database.SqlQuery<Profile>("profile_updateProfile @username,@fname,@lname,@birthday,@phonenumber,@email,@address,@city,@country,@postalcode,@aboutme", sqlParams).SingleOrDefault();
            return res;
        }
    }
}
