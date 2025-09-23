using Newtonsoft.Json;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Ahrefs.Models;

public class Keyword
{
    [JsonProperty("keyword")]
    [Display("Keyword")]
    public string Word { get; set; }

    [JsonProperty("clicks")]
    [Display("Clicks")]
    public int Clicks { get; set; }

    [JsonProperty("cpc")]
    [Display("Cost per click")]
    public int CostPerClick { get; set; }

    [JsonProperty("cps")]
    [Display("Clicks per search")]
    public double ClicksPerSearch { get; set; }
}
