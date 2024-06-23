using System.ComponentModel.DataAnnotations.Schema;

namespace Webui.Apps.Models
{
    public class Location
    {
        public string LocationId { get; set; } = string.Empty;

        public string LocationName { get; set; } = string.Empty;
    }
}
