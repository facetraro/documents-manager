using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentsManager.Web.Api.Models
{
    public class LogInModel
    {
        public string Password { get; set; }
        public LogInModel(string password)
        {
            Password = password;
        }

        public LogInModel()
        {
            Password = "DefaultPassword";
        }

    }
}