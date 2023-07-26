using System;
using System.Collections.Generic;

namespace Project220723.Models
{
    public partial class PraveenUserRoleMapper
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual PraveenRole Role { get; set; } = null!;
        public virtual PraveenLoginCredential User { get; set; } = null!;
    }
}
