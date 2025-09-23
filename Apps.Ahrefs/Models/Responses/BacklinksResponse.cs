using Newtonsoft.Json;

namespace Apps.Ahrefs.Models.Responses;

public class BacklinksResponse
{
    [JsonProperty("backlinks")]
    public List<Backlink> Backlinks { get; set; }
}
