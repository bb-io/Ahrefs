using Newtonsoft.Json;
using Apps.Ahrefs.Models.Entities;

namespace Apps.Ahrefs.Models.Responses.SiteExplorer;

public class VolumeByCountryResponse
{
    [JsonProperty("countries")]
    public List<VolumeByCountry> VolumeByCountry { get; set; }
}
