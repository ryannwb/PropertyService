using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyService.Models
{
    public class InfoPerson
    {
        private int IDPerson;

        public int ID
        {
            get { return IDPerson; }
            set { IDPerson = value; }
        }
        private string FullName;

        public string Name
        {
            get { return FullName; }
            set { FullName = value; }
        }
        private string PhoneNumber1;
        

        public string Phone1
        {
            get { return PhoneNumber1; }
            set { PhoneNumber1 = value; }
        }
        private string PhoneNumber2;

        public string Phone2
        {
            get { return PhoneNumber2; }
            set { PhoneNumber2 = value; }
        }
        private string EmailAddress;

        public string Email
        {
            get { return EmailAddress; }
            set { EmailAddress = value; }
        }
        private string UserID;

        public string Username
        {
            get { return UserID; }
            set { UserID = value; }
        }
        private string Pass;

        public string Password
        {
            get { return Pass; }
            set { Pass = value; }
        }

        private string UserLevel;

        public string Level
        {
            get { return UserLevel; }
            set { UserLevel = value; }
        }

        
    }
}