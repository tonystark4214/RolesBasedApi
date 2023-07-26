using System;
using System.Collections.Generic;

namespace Project220723.Models
{
    public partial class PraveenRole
    {
        public PraveenRole()
        {
            PraveenUserRoleMappers = new HashSet<PraveenUserRoleMapper>();
        }

        public int RoleId { get; set; }
        public string RolesName { get; set; } = null!;

        public virtual ICollection<PraveenUserRoleMapper> PraveenUserRoleMappers { get; set; }
    }
}
