using Altom.AltUnityDriver;
using alttrashcat_tests_csharp.pages;
using System;
using System.Threading;
using NUnit.Framework;
namespace alttrashcat_tests_csharp.tests
{
    public class LeaderBoardTests
    {
        private MainMenuPage mainMenuPage;
        private LeaderBoardPage leaderBoardPage;
        private AltUnityDriver altUnityDriver;


        [SetUp]
        public void SetupBeforeEachTest()
        {
            altUnityDriver = new AltUnityDriver(port: 13000);
            mainMenuPage = new MainMenuPage(altUnityDriver);
            mainMenuPage.LoadScene();
            leaderBoardPage = new LeaderBoardPage(this.altUnityDriver);
        }

        [TearDown]
        public void Dispose()
        {
            altUnityDriver.Stop();
        }


        [Test]
        public void TestLeaderboardLoadedCorrectly()
        {
            mainMenuPage.LeaderBoardButton.Click();
            Assert.True(leaderBoardPage.IsDisplayed());
        }


    }
}