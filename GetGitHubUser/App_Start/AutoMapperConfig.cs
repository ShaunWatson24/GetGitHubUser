using System.Net;

namespace GetGitHubUser.App_Start
{
    public class AutoMapperConfig
    {
        public static void Register()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }
    }
}