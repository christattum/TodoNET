using System.Collections.Generic;

namespace TodoNET.Model
{
    public class Role
    {
        public virtual ICollection<User> Users { get; protected set; }
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public Role()
        {
            Users = new HashSet<User>();
        }


    }
}
