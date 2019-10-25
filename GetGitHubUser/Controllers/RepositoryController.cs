using GetGitHubUser.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace GetGitHubUser.Controllers
{
    public class RepositoryController : Controller
    {
        // GET: Repositories
        public ActionResult Index(string repoUrl)
        {
            var repos = new List<GitHubRepository>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(repoUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");

                var response = client.GetAsync("").Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;

                    repos = JsonConvert.DeserializeObject<List<GitHubRepository>>(result);
                }
            }

            return View(repos.OrderByDescending(r => r.StargazerCount).Take(5));
        }
    }
}