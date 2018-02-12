using PropertyService.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PropertyService.Controllers
{
    public class CheckConnectionController : ApiController
    {
        CheckConnection cc = new CheckConnection();

        public CheckConnection GetAllConnection()
        {
            //checking connection 
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AWSPropertyDB"].ConnectionString);
            try
            {
                conn.Open();
                return cc;
                conn.Close();
            }
            catch (Exception err)
            {
                cc.CodeConnection = 2;
                cc.MessageSuccess = "Cannot Connect to Database";
                return cc;
            }
            
        }
    }
}
