using System.Text.Json.Serialization;

namespace Webui.Apps.Models
{
    public class BpkbTransaction
    {
        [JsonPropertyName("agreementNumber")]
        public string AgreementNumber { get; set; } = string.Empty;
        [JsonPropertyName("bpkbNo")]
        public string BpkbNo { get; set; } = string.Empty;
        [JsonPropertyName("branchId")]
        public string BranchId { get; set; } = string.Empty;
        [JsonPropertyName("bpkbDate")]
        public DateTime? BpkbDate { get; set; }
        [JsonPropertyName("fakturNo")]
        public string FakturNo { get; set; } = string.Empty;
        [JsonPropertyName("fakturDate")]
        public DateTime? FakturDate { get; set; }
        [JsonPropertyName("locationId")]
        public string LocationId { get; set; } = string.Empty;
        [JsonPropertyName("policeNo")]
        public string PoliceNo { get; set; } = string.Empty;
        [JsonPropertyName("bpkbDateIn")]
        public DateTime? BpkbDateIn { get; set; }
    }
}
