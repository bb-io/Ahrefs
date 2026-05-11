using Newtonsoft.Json;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Ahrefs.Models.Entities;

public class KeywordIdea : IKeyword
{
    [JsonProperty("keyword")]
    [Display("Keyword")]
    public string Word { get; set; }

    [JsonProperty("cpc")]
    [Display("Cost per click")]
    public int? CostPerClick { get; set; }

    [JsonProperty("cps")]
    [Display("Clicks per search")]
    public double? ClicksPerSearch { get; set; }

    [JsonProperty("volume")]
    [Display("Volume")]
    public int? Volume { get; set; }

    [JsonProperty("first_seen")]
    [Display("First seen")]
    public DateTime? FirstSeen { get; set; }
}
