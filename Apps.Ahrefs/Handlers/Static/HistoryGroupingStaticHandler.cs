using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Ahrefs.Handlers.Static;

public class HistoryGroupingStaticHandler : IStaticDataSourceItemHandler
{
    public IEnumerable<DataSourceItem> GetData()
    {
        return new List<DataSourceItem>
        {
            new DataSourceItem("daily", "Daily"),
            new DataSourceItem("weekly", "Weekly"),
            new DataSourceItem("monthly", "Monthly")
        };
    }
}
