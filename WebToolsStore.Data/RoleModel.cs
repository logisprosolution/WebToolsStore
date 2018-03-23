using System;
using System.Collections.Generic;
using System.Data;

namespace WebToolsStore.Data
{
    public class RoleModel
    {
        private USR_Role _role = new USR_Role();
        public virtual USR_Role USR_Role
        {
            get { return _role; }
            set { _role = value; }
        }
        private USR_Role_Submenu _role_submenu = new USR_Role_Submenu();
        public virtual USR_Role_Submenu USR_Role_Submenu
        {
            get { return _role_submenu; }
            set { _role_submenu = value; }
        }
        private List<USR_Role_Submenu> _roleSubmenuList = new List<USR_Role_Submenu>();
        public virtual List<USR_Role_Submenu> RoleSubmenuList
        {
            get { return _roleSubmenuList; }
            set { _roleSubmenuList = value; }
        }

        private USR_User_Role _user_role = new USR_User_Role();
        public virtual USR_User_Role USR_User_Role
        {
            get { return _user_role; }
            set { _user_role = value; }
        }
        private List<USR_User_Role> _userroleList = new List<USR_User_Role>();
        public virtual List<USR_User_Role> UserRoleList
        {
            get { return _userroleList; }
            set { _userroleList = value; }
        }
    }
}