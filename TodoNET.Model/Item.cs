using System;
using System.ComponentModel.DataAnnotations;

namespace TodoNET.Model
{
    public class Item
    {
        public virtual int Id { get; protected set; }

        [Required]
        public virtual string Summary { get; set; }

        public virtual string Detail { get; set; }

        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString="{0:d}")]
        public virtual DateTime? CompletedDate { get; set; }

        public virtual Project Project { get; set; }

        #region Object overrides
        public override bool Equals(object obj)
        {
            if (obj is Item)
            {
                var compareTo = (Item)obj;
                return compareTo.Id == Id;
            }
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return Summary;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        #endregion
    }
}
