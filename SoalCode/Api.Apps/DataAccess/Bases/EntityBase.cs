using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Bases
{
    public class EntityBase
    {
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? Modified { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
