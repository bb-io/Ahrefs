using Newtonsoft.Json;
using Apps.Ahrefs.Models.Utility;
using Apps.Ahrefs.Models.Entities;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Ahrefs.Models.Responses.KeywordExplorer;

public class VolumeByCountryResponse : UnitsResponse
{
    [JsonProperty("countries")]
    [Display("Volume by country")]
    public List<VolumeByCountry> VolumeByCountry { get; set; }
}
