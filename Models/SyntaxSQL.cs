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
        
    }
}