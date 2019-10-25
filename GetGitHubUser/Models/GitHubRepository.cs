using Newtonsoft.Json;

namespace GetGitHubUser.Models
{
    public class GitHubRepository
    {
        [JsonProperty("name")]
        public string RepositoryName { get; set; } = string.Empty;
        [JsonProperty("html_url")]
        public string RepositoryUrl { get; set; } = string.Empty;
        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;
        [JsonProperty("stargazers_count")]
        public int StargazerCount { get; set; } = 0;
    }
}