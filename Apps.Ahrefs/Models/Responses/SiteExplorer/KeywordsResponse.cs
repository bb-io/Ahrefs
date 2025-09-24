using Apps.Ahrefs.Models.Entities;
using Newtonsoft.Json;

namespace Apps.Ahrefs.Models.Responses.SiteExplorer;

public class KeywordsResponse
{
    [JsonProperty("keywords")]
    public List<Keyword> Keywords { get; set; }
}
