using Newtonsoft.Json;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Ahrefs.Models.Entities;

public class VolumeHistory
{
    [JsonProperty("date")]
    [Display("Date")]
    public DateTime Date { get; set; }

    [JsonProperty("volume")]
    [Display("Volume")]
    public int Volume { get; set; }
}
