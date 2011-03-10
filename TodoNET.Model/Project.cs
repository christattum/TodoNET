using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TodoNET.Model
{
    public class Project
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        public virtual ICollection<Item> Items { get; protected set; }

        public Project()
        {
            Items = new HashSet<Item>();
        }

        #region Object overrides
        public override bool Equals(object obj)
        {
            if (obj is Project)
            {
                var compareTo = (Project)obj;
                return compareTo.Id == Id;
            }
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return Name;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        #endregion

    }
}
