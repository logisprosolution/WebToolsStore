using System.Collections.Generic;
using System.Data;

namespace WebToolsStore.Data
{
    public class LogInModel
    {
        private USR_User_Profile _profile = new USR_User_Profile();

        public virtual USR_User_Profile USR_User_Profile
        {
            get { return _profile; }
            set { _profile = value; }
        }

        private USR_User _user = new USR_User();

        public virtual USR_User USR_User
        {
            get { return _user; }
            set { _user = value; }
        }

        private string _username;

        public virtual string user_name
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _password;

        public virtual string user_password
        {
            get { return _password; }
            set { _password = value; }
        }
    }
}