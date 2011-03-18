using System;
using System.Web.Security;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Specialized;
using NHibernate;
using NHibernate.Criterion;
using TodoNET.Model;

namespace TodoNET.Authentication
{
    class TodoRoleProvider : RoleProvider
    {
        /// <summary>Initializes the provider.</summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        [SuppressMessage("Microsoft.Security", "CA2123:OverrideLinkDemandsShouldBeIdenticalToBase")]
        [SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "System.Text.RegularExpressions.Regex", Justification = "This is a fair use, as we check if the RegEx is valid or not, even if the instance is not used later")]
        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            if (String.IsNullOrEmpty(name))
            {
                name = "AperioMembershipProvider";
            }
            if (String.IsNullOrEmpty(config["description"]))
            {
                config.Add("description", "Aperio Membership Provider (c) Chris Tattum 2009");
            }

            base.Initialize(name, config);
        }

        public override string[] GetRolesForUser(string username)
        {
            try
            {
                using (ISession session = MvcApplication.SessionFactory.OpenSession())
                {
                    // fetch the user, then read the roles out!
                    var user = session.CreateCriteria<User>()
                        .Add(Expression.Eq("UserName", username))
                        .UniqueResult<User>();

                    if (user == null)
                        return new string[0];

                    // if the user exists, collect the role names
                    string[] roles = new string[user.Roles.Count];

                    // now read the roles out
                    int n = 0;
                    foreach (Role role in user.Roles)
                    {
                        roles[n++] = role.Name;
                    }

                    return roles;
                }
            }
            catch (HibernateException ex)
            {
                throw new Exception("Error while accessing the database", ex);
            }

        }


        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

    

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
