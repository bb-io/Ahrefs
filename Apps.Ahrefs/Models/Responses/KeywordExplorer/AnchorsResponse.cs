using Apps.Ahrefs.Models.Entities;
using Newtonsoft.Json;

namespace Apps.Ahrefs.Models.Responses.KeywordExplorer;

public class AnchorsResponse
{
    [JsonProperty("anchors")]
    public List<Anchor> Anchors { get; set; }
}
