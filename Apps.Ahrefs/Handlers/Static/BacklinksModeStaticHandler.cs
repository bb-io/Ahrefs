using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Ahrefs.Handlers.Static;

public class BacklinksModeStaticHandler : IStaticDataSourceItemHandler
{
    public IEnumerable<DataSourceItem> GetData()
    {
        return new List<DataSourceItem>
        {
            new DataSourceItem("exact", "Exact URL"),
            new DataSourceItem("prefix", "Prefix"),
            new DataSourceItem("domain", "Domain"),
            new DataSourceItem("subdomains", "Subdomains"),
        };
    }
}
