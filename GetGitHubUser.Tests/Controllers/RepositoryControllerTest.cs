using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GetGitHubUser.Controllers;
using GetGitHubUser.App_Start;
using FluentAssertions;
using System.Collections.Generic;
using GetGitHubUser.Models;
using System.Linq;

namespace GetGitHubUser.Tests.Controllers
{
    [TestClass]
    public class RepositoryControllerTest
    {
        [TestInitialize()]
        public void Initialize()
        {
            AutoMapperConfig.Register();
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            RepositoryController controller = new RepositoryController();

            // Act
            ViewResult result = controller.Index("https://api.github.com/users/ShaunWatson24/repos") as ViewResult;

            // Assert
            result.Should().NotBeNull();
            var repos = ((IEnumerable<GitHubRepository>)result.ViewData.Model).ToList();

            repos.Count.Should().Be(5);
            var repo = repos.FirstOrDefault();
            repo.RepositoryName.Should().Be("GetGitHubUser");
            repo.RepositoryUrl.Should().Be("https://github.com/ShaunWatson24/GetGitHubUser");
            repo.StargazerCount.Should().Be(1);
            repo.Description.Should().Be(null);
        }
    }
}
