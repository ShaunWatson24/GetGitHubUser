using Newtonsoft.Json;

namespace GetGitHubUser.Models
{
    public class GitHubUserModel
    {
        [JsonProperty("id")]
        public int Id { get; set; } = 0;
        [JsonProperty("login")]
        public string Username { get; set; } = string.Empty;
        [JsonProperty("name")]
        public string FullName { get; set; } = string.Empty;
        [JsonProperty("location")]
        public string Location { get; set; } = string.Empty;
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; } = string.Empty;
        [JsonProperty("repos_url")]
        public string RepositoriesUrl { get; set; } = string.Empty;
        [JsonProperty("html_url")]
        public string ProfileUrl { get; set; } = string.Empty;
    }
}