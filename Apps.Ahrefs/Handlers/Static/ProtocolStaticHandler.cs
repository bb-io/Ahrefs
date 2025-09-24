using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Ahrefs.Handlers.Static;

public class ProtocolStaticHandler : IStaticDataSourceItemHandler
{
    public IEnumerable<DataSourceItem> GetData()
    {
        return new List<DataSourceItem>
        {
            new DataSourceItem("http", "HTTP"),
            new DataSourceItem("https", "HTTPS"),
            new DataSourceItem("both", "Both"),
        };
    }
}
