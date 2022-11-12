using Altom.AltUnityDriver;
using alttrashcat_tests_csharp.pages;
using System;
using System.Threading;
using NUnit.Framework;
namespace alttrashcat_tests_csharp.tests
{
    public class LeaderBoardTests
    {
        AltUnityDriver altUnityDriver;
        MainMenuPage mainMenuPage;
        LeaderBoardPage leaderBoardPage;


        [SetUp]
        public void Setup()
        {
            altUnityDriver = new AltUnityDriver(port: 13000);
            mainMenuPage = new MainMenuPage(altUnityDriver);
            mainMenuPage.LoadScene();
            leaderBoardPage = new LeaderBoardPage(altUnityDriver);
        }

        [TearDown]
        public void Dispose()
        {
            altUnityDriver.Stop();
            Thread.Sleep(1000);
        }


        [Test]
        public void TestLeaderboardLoadedCorrectly()
        {
            mainMenuPage.LeaderBoardButton.Click();
            Assert.True(leaderBoardPage.IsDisplayed());
        }


    }
}