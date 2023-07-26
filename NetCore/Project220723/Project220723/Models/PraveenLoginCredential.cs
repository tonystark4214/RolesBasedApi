using System;
using System.Collections.Generic;

namespace Project220723.Models
{
    public partial class PraveenLoginCredential
    {
        public PraveenLoginCredential()
        {
            PraveenUserRoleMappers = new HashSet<PraveenUserRoleMapper>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool? IsDeleted { get; set; }

        public virtual ICollection<PraveenUserRoleMapper> PraveenUserRoleMappers { get; set; }
    }
}
