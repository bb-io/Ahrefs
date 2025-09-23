using Apps.Ahrefs.Actions;
using Tests.Appname.Base;

namespace Tests.Ahrefs;

[TestClass]
public class ActionTests : TestBase
{
    [TestMethod]
    public async Task Dynamic_handler_works()
    {
        var actions = new Actions(InvocationContext);

        await actions.Action();
    }
}
