using Newtonsoft.Json;
using Apps.Ahrefs.Models.Utility;
using Apps.Ahrefs.Models.Entities;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Ahrefs.Models.Responses.KeywordExplorer;

public class VolumeHistoryResponse : UnitsResponse
{
    [JsonProperty("metrics")]
    [Display("Volume history")]
    public List<VolumeHistory> VolumeHistory { get; set; }
}
