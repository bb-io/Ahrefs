using Apps.Ahrefs.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Blackbird.Applications.Sdk.Utils.RestSharp;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Apps.Ahrefs.Api;

public class AhrefsClient : BlackBirdRestClient
{
    public AhrefsClient(IEnumerable<AuthenticationCredentialsProvider> creds) : base(new()
    {
        BaseUrl = new Uri("https://api.ahrefs.com/v3/"),
    })
    {
        this.AddDefaultHeader("Authorization", creds.Get(CredsNames.ApiKey).Value);
    }

    protected override Exception ConfigureErrorException(RestResponse response)
    {
        var errorArray = JArray.Parse(response.Content);

        var type = errorArray[0].ToString();
        var details = errorArray[1] as JArray;

        var errorMessage = $"{type}: {string.Join(" - ", details)}";

        throw new PluginApplicationException(errorMessage);
    }
}