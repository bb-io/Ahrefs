using Newtonsoft.Json;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Ahrefs.Models.Entities;

public class KeywordHistory
{
    [JsonProperty("date")]
    [Display("Date")]
    public DateTime Date { get; set; }

    [JsonProperty("top3")]
    [Display("Top 3")]
    public int Top3 { get; set; }

    [JsonProperty("top4_10")]
    [Display("Top 4-10")]
    public int Top4_10 { get; set; }

    [JsonProperty("top11_plus")]
    [Display("Top 11+")]
    public int Top11Plus { get; set; }

    [JsonProperty("top11_20")]
    [Display("Top 11-20")]
    public int Top11_20 { get; set; }

    [JsonProperty("top21_50")]
    [Display("Top 21-50")]
    public int Top21_50 { get; set; }

    [JsonProperty("top51_plus")]
    [Display("Top 51+")]
    public int Top51Plus { get; set; }
}
