using Microsoft.Graph;

namespace Taskills.WebApi;

public static class AppConfig
{
    public static GraphServiceClient GraphClient { get; set; }
    public static ConfigurationManager Configuration { get; set; }
}