using Altom.AltUnityDriver;
using TestAltTrashCatCSharp.pages;
using NUnit.Framework;

namespace TestAltTrashCatCSharp.tests
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