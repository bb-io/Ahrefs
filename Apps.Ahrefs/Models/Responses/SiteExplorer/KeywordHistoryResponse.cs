using Apps.Ahrefs.Models.Entities;
using Newtonsoft.Json;

namespace Apps.Ahrefs.Models.Responses.SiteExplorer;

public class KeywordHistoryResponse
{
    [JsonProperty("keywords")]
    public List<KeywordHistory> KeywordHistory { get; set; }
}
