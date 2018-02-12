using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyService.Models
{
    public class CheckConnection
    {
        private string Success="Connection OK";
        private int Code = 1;

        public int CodeConnection
        {
            get { return Code; }
            set { Code = value; }
        }


        public string MessageSuccess
        {
            get { return Success; }
            set { Success = value; }
        }


    }
}
