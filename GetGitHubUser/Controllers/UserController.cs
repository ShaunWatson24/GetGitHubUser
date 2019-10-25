using GetGitHubUser.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace GetGitHubUser.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index(string username)
        {
            GitHubUserModel user = new GitHubUserModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.github.com");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");

                var response = client.GetAsync($"/users/{username}").Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;

                    user = JsonConvert.DeserializeObject<GitHubUserModel>(result);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, $"User {username} was not found or the Github Api is experiencing issues. Check the status here: https://www.githubstatus.com/");
                }
            }

            return View(user);
        }
    }
}