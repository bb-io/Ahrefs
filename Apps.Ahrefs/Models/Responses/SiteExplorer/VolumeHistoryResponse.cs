using Newtonsoft.Json;
using Apps.Ahrefs.Models.Entities;

namespace Apps.Ahrefs.Models.Responses.SiteExplorer;

public class VolumeHistoryResponse
{
    [JsonProperty("metrics")]
    public List<VolumeHistory> VolumeHistory { get; set; }
}
