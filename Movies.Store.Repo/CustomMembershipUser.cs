using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Web.Security;

namespace MovieStore.Repo
{
    internal class CustomMembershipUser : MembershipUser
    {
        public int UserID { get; set; }
        public ICollection<Role> Roles { get; set; }

        public CustomMembershipUser(User user) : base("CustomMembership", user.UserName, user.ID, user.Email, string.Empty, string.Empty, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now)
        {
            UserID = user.ID;
            Roles = user.Roles;
        }
    }
}