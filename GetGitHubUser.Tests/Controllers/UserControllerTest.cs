using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GetGitHubUser.Controllers;
using FluentAssertions;
using GetGitHubUser.App_Start;
using GetGitHubUser.Models;

namespace GetGitHubUser.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
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
            UserController controller = new UserController();

            // Act
            ViewResult result = controller.Index("ShaunWatson24") as ViewResult;

            // Assert
            result.Should().NotBeNull();
            result.ViewData.Model.Should().BeOfType<GitHubUserModel>();

            var model = result.ViewData.Model as GitHubUserModel;
            model.FullName.Should().Be("Shaun Watson");
            model.Location.Should().Be("Sunderland");
            model.Id.Should().Be(29128264);
            model.Username.Should().Be("ShaunWatson24");
            model.RepositoriesUrl.Should().Be("https://api.github.com/users/ShaunWatson24/repos");
            model.AvatarUrl.Should().Be("https://avatars3.githubusercontent.com/u/29128264?v=4");
            model.ProfileUrl.Should().Be("https://github.com/ShaunWatson24");
        }
    }
}
