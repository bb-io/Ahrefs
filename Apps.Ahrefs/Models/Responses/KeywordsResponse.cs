using Apps.Ahrefs.Models.Entities;
using Newtonsoft.Json;

namespace Apps.Ahrefs.Models.Responses;

public class KeywordsResponse
{
    [JsonProperty("keywords")]
    public List<Keyword> Keywords { get; set; }
}
