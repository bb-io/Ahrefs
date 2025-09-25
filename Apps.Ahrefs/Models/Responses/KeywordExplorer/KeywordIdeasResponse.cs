using Newtonsoft.Json;
using Apps.Ahrefs.Models.Utility;
using Apps.Ahrefs.Models.Entities;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Ahrefs.Models.Responses.KeywordExplorer;

public class KeywordIdeasResponse : UnitsResponse
{
    [JsonProperty("keywords")]
    [Display("Keywords")]
    public List<KeywordIdea> Keywords { get; set; }
}
