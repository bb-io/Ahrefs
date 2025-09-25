using Newtonsoft.Json;
using Apps.Ahrefs.Models.Utility;
using Apps.Ahrefs.Models.Entities;

namespace Apps.Ahrefs.Models.Responses.SiteExplorer;

public class AnchorsResponse : UnitsResponse
{
    [JsonProperty("anchors")]
    public List<Anchor> Anchors { get; set; }
}
