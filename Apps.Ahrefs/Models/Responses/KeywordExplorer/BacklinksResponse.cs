using Apps.Ahrefs.Models.Entities;
using Newtonsoft.Json;

namespace Apps.Ahrefs.Models.Responses.KeywordExplorer;

public class BacklinksResponse
{
    [JsonProperty("backlinks")]
    public List<Backlink> Backlinks { get; set; }
}
