using DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    [Table("tr_bpkb")]
    public class BpkbTransaction : EntityBase
    {
        [Key]
        [Column("agreement_number")]
        public string AgreementNumber { get; set; } = string.Empty;

        [Column("bpkb_no")]
        public string BpkbNo { get; set; } = string.Empty;

        [Column("branch_id")]
        public string BranchId { get; set; } = string.Empty;

        [Column("bpkb_date")]
        public DateTime? BpkbDate { get; set; }

        [Column("faktur_no")]
        public string FakturNo { get; set; } = string.Empty;

        [Column("faktur_date")]
        public DateTime? FakturDate { get; set; }

        [Column("location_id")]
        public string LocationId { get; set; } = string.Empty;

        [Column("police_no")]
        public string PoliceNo { get; set; } = string.Empty;

        [Column("bpkb_date_in")]
        public DateTime? BpkbDateIn { get; set; }

        public virtual Location Location { get; set; } = null!;
    }
}
