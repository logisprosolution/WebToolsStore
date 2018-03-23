using System.Collections.Generic;
using System.Data;

namespace WebToolsStore.Data
{
    public class UserModel
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
        private string _searchText;

        public virtual string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; }
        }
        private string _searchName;

        public virtual string SearchName
        {
            get { return _searchName; }
            set { _searchName = value; }
        }
        private string _searchLastname;

        public virtual string SearchLastname
        {
            get { return _searchLastname; }
            set { _searchLastname = value; }
        }
    }
}