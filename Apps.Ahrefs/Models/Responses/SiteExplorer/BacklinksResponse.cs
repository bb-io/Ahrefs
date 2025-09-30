using Newtonsoft.Json;
using Apps.Ahrefs.Models.Utility;
using Apps.Ahrefs.Models.Entities;

namespace Apps.Ahrefs.Models.Responses.SiteExplorer;

public class BacklinksResponse : UnitsResponse
{
    [JsonProperty("backlinks")]
    public List<Backlink> Backlinks { get; set; }
}
