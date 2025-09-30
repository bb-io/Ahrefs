using Apps.Ahrefs.Handlers.Static;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Ahrefs.Models.Requests.SiteExplorer;

public class GetKeywordHistoryRequest
{
    [Display("Target", Description = "The target of the search: a domain or a URL")]
    public string Target { get; set; }

    [Display("History grouping", Description = "The time interval used to group historical data")]
    [StaticDataSource(typeof(HistoryGroupingStaticHandler))]
    public string? HistoryGrouping { get; set; }

    [Display("Mode", Description = "The scope of the search based on the target you entered")]
    [StaticDataSource(typeof(ModeStaticHandler))]
    public string? Mode { get; set; }
}
