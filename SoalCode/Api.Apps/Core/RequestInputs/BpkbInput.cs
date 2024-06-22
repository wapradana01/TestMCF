using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RequestInputs
{
    public class BpkbInput
    {
        public string AgreementNumber { get; set; } = string.Empty;
        public string BpkbNo { get; set; } = string.Empty;
        public string BranchId { get; set; } = string.Empty;
        public DateTime? BpkbDate { get; set; }
        public string FakturNo { get; set; } = string.Empty;
        public DateTime? FakturDate { get; set; }
        public string LocationId { get; set; } = string.Empty;
        public string PoliceNo { get; set; } = string.Empty;
        public DateTime? BpkbDateIn { get; set; }
    }
}
