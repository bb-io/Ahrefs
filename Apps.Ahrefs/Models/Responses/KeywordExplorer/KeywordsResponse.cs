using Newtonsoft.Json;
using Apps.Ahrefs.Models.Utility;
using Apps.Ahrefs.Models.Entities;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Ahrefs.Models.Responses.KeywordExplorer;

public class KeywordsResponse : UnitsResponse
{
    [JsonProperty("keywords")]
    [Display("Keywords")]
    public List<Keyword> Keywords { get; set; }

    [Display("All words")]
    public string AllKeywords => string.Join(", ", Keywords.Select(x => x.Word));
}
