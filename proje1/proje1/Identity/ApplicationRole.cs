using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proje1.Identity
{
    public class ApplicationRole:IdentityRole
    {
        public string Aciklama { get; set; }
        public ApplicationRole()
        {


        }
        public ApplicationRole(string rolename, string aciklama)
        {
            this.Aciklama = aciklama;


        }
    }

}