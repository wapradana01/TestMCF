using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SharedObjects
{
    public class CurrentUserAccessor
    {
        public long Id { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}
