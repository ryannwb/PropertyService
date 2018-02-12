﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PropertyService.Models;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace PropertyService.Controllers
{
    public class InfoPersonController : ApiController
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AWSPropertyDB"].ConnectionString);
        //InfoPerson infoperson = new InfoPerson();
        InfoPerson[] person =  new InfoPerson[]{};

        public IEnumerable<InfoPerson> GetAllPerson()
        {
            SyntaxSQL syntaxsql = new SyntaxSQL();
            List<InfoPerson> data = new List<InfoPerson>();

            //string syntax = syntaxsql.SyntaxAllPerson;
            SqlDataReader rd = OpenConnection(syntaxsql.SyntaxAllPerson);
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    data.Add(
                        new InfoPerson
                        {
                            ID = Convert.ToInt16(rd["IDPerson"].ToString()),
                            Name = rd["Fullname"].ToString(),
                            Phone1 = rd["NoHP1"].ToString(),
                            Phone2 = rd["NoHP2"].ToString(),
                            Email = rd["Email"].ToString(),
                            Password = rd["Password"].ToString(),
                            Username = rd["UserID"].ToString(),
                            Level = rd["UserLevel"].ToString()
                        }
                    );
                }
            }
            person = data.ToArray();
            return person;
        }


        //public InfoPerson AuthPerson(string user, string pass,string level)
        //{
        //    InfoPerson info = new InfoPerson();
        //    SyntaxSQL syntaxsql = new SyntaxSQL();

        //    syntaxsql.SettingSignIn(user,pass,level);

        //    string sysSignIn = syntaxsql.SyntaxSignIn;
        //    SqlDataReader rd = OpenConnection(sysSignIn);

        //    if (rd.HasRows)
        //    {
        //        info.ID = Convert.ToInt16(rd["IDPerson"].ToString());
        //        info.Name = rd["Fullname"].ToString();
        //        info.Phone1 = rd["NoHP1"].ToString();
        //        info.Phone2 = rd["NoHP2"].ToString();
        //        info.Email = rd["Email"].ToString();
        //        info.Username = rd["UserID"].ToString();
        //        info.Level = rd["UserLevel"].ToString();
        //    }

        //    return info;
        //}

        public SqlDataReader OpenConnection(string syntax)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(syntax, conn);
            SqlDataReader result = cmd.ExecuteReader();
            return result;
        }

        public string DecryptePass(string pass, string mess)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(pass));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the decoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToDecrypt = Convert.FromBase64String(mess);

            // Step 5. Attempt to decrypt the string
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the decrypted string in UTF8 format
            return UTF8.GetString(Results);
        }

        public string EncryptPass(string pass, string mess)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(pass));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the encoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(mess);

            // Step 5. Attempt to encrypt the string
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the encrypted string as a base64 encoded string
            return Convert.ToBase64String(Results);
        }
    }
}