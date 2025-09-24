using Apps.Ahrefs.Models.Entities;
using Newtonsoft.Json;

namespace Apps.Ahrefs.Models.Responses.KeywordExplorer;

public class KeywordIdeasResponse
{
    [JsonProperty("keywords")]
    public List<KeywordIdea> Keywords { get; set; }
}
