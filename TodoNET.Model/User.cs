using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AperioReal.Membership
{
    public class User
    {
        public virtual ICollection<Role> Roles { get; protected set; }

        public virtual int Id { get; set; }

        [Required(ErrorMessage = "Please enter a user name")] [StringLength(50)]
        public virtual string UserName { get; set; }
        
        [Required(ErrorMessage= "Please enter a valid email address")] [StringLength(100)]
        public virtual string Email { get; set; }

        [Required(ErrorMessage = "Please enter a password")] [StringLength(50)]
        public virtual string Password { get; set; }
        
        public virtual bool LockedOut { get; set; }

        public virtual bool IsAdmin()
        {
            // Admin user is first added user, so has Id of 1
            return (Id == 1);
        }

        public User()
        {
            Roles = new HashSet<Role>();
        }

    }
}
