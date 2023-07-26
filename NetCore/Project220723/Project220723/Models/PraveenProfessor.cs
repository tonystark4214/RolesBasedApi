using System;
using System.Collections.Generic;

namespace Project220723.Models
{
    public partial class PraveenProfessor
    {
        public int ProfId { get; set; }
        public string? ProfName { get; set; }
        public string? ProfEmail { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public string? ProfUserName { get; set; }
    }
}
