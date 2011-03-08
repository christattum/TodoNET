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
    }
}
