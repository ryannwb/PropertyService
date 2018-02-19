using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyService.Models
{
    public class SyntaxSQL
    {
        private string SignIn="SignIn {0},{1},{2}";
        private string allPerson="select * from Information_Person";
        private string RegisterPerson = "RegisterUser";
        private string SyntaxRegisterPerson = "exec dbo.RegisterUser {0},{1},{2},{3},{4},{5},{6},{7}";

        public string SyntaxAllPerson
        {
            get { return allPerson; }
            set { allPerson = value; }
        }

        public string SyntaxSignIn
        {
            get { return SignIn; }
            set { SignIn = value; }
        }

        public void SettingSignIn(string username, string password,string level){
            string result;
            result = String.Format(SignIn,username,password,level);
            SignIn = result;
        }

        public void SettingRegisterPerson(string fullname, string nohp1, string nohp2, string email, string username, string password, string userlevel)
        {
            string result;
            result = String.Format(SyntaxRegisterPerson, fullname, nohp1, nohp2, email, username, password, userlevel);
            SyntaxRegisterPerson = result;
        }
        
    }
}