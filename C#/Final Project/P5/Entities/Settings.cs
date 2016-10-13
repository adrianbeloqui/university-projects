using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Settings
    {
        private bool loadFiles;
        private bool automaticSave;
        private bool onlyAdminLogin;
        private bool allUsersLogin;
        private bool allowAdminsCreation;
        private bool basicUserAdmin;
        private string basicUserAdminName;
        private string basicUserAdminPassword;
        private bool tutorial;

        #region Properties


        public bool LoadFiles
        {
            get { return loadFiles; }
            set { loadFiles = value; }
        }
        public bool AutomaticSave
        {
            get { return automaticSave; }
            set { automaticSave = value; }
        }
        public bool OnlyAdminLogin
        {
            get { return onlyAdminLogin; }
            set { onlyAdminLogin = value; }
        }
        public bool AllUsersLogin
        {
            get { return allUsersLogin; }
            set { allUsersLogin = value; }
        }

        public bool AllowAdminsCreation
        {
            get { return allowAdminsCreation; }
            set { allowAdminsCreation = value; }
        }
        
        public string BasicUserAdminName
        {
            get { return basicUserAdminName; }
            set { basicUserAdminName = value; }
        }

        public string BasicUserAdminPassword
        {
            get { return basicUserAdminPassword; }
            set { basicUserAdminPassword = value; }
        }

        public bool BasicUserAdmin
        {
            get { return basicUserAdmin; }
            set { basicUserAdmin = value; }
        }

        public bool Tutorial
        {
            get { return tutorial; }
            set { tutorial = value; }
        }

#endregion
    }
}
