using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TodoNET.Model
{
    public class Item
    {
        public virtual int ItemId { get; protected set; }
        public virtual string Summary { get; set; }
        public virtual string Detail { get; set; }
        public virtual DateTime? CompletedDate { get; set; }

        public virtual Project Project { get; set; }
    }
}
