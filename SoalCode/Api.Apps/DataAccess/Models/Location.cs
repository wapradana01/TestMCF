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
    [Table("ms_storage_location")]
    public class Location : EntityBase
    {
        [Key]
        [Column("location_id")]
        public string LocationId { get; set; } = string.Empty;


        [Column("location_name")]
        public string LocationName { get; set; } = string.Empty;

        public virtual List<BpkbTransaction>? BpkbTransactions { get; set; }
    }
}
