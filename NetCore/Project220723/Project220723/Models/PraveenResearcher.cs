using System;
using System.Collections.Generic;

namespace Project220723.Models
{
    public partial class PraveenResearcher
    {
        public int ResId { get; set; }
        public string? ResName { get; set; }
        public string? ResEmail { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public string? ResUserName { get; set; }
    }
}
