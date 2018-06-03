using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Repo
{
    public class CustomPrincipal : IPrincipal
    {
        public int UserID { get; set; }
        public ICollection<Role> Roles { get; set; }
        public IIdentity Identity
        {
            get; private set;
        }

        public CustomPrincipal(string username)
        {
            Identity = new GenericIdentity(username);
        }

        public bool IsInRole(string role)
        {
            if (Roles.Any(r => r.Name.Contains(role)))
            {
                return true;
            }
            else return false;
        }
    }
}
