using Newtonsoft.Json;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Ahrefs.Models.Entities;

public class VolumeByCountry
{
    [JsonProperty("country")]
    [Display("Country")]
    public string Country { get; set; }

    [JsonProperty("volume")]
    [Display("Volume")]
    public int Volume { get; set; }
}
