using System;
using Altom.AltUnityDriver;
using TestAltTrashCatCSharp.pages;
using NUnit.Framework;

namespace TestAltTrashCatCSharp.tests
{
    public class GamePlayTests
    {
        private AltUnityDriver altUnityDriver;
        private  MainMenuPage mainMenuPage;
        private GamePlay gamePlayPage;
        private  PauseOverlayPage pauseOverlayPage;
        private GetAnotherChancePage getAnotherChancePage;

        [SetUp]
        public void SetupBeforeEachTest()
        {
            altUnityDriver = new AltUnityDriver(port: 13000);
            mainMenuPage = new MainMenuPage(altUnityDriver);
            mainMenuPage.LoadScene();
            mainMenuPage.PressRun();
            gamePlayPage = new GamePlay(altUnityDriver);
            pauseOverlayPage = new PauseOverlayPage(altUnityDriver);
            getAnotherChancePage = new GetAnotherChancePage(altUnityDriver);
        }
        [Test]
        public void TestGamePlayScreenDisplayedCorrectly()
        {
            Assert.True(gamePlayPage.IsDisplayed());
        }
        [Test]
        public void TestGamePausedAndResumedCorrectly()
        {
            gamePlayPage.PressPause();
            Assert.True(pauseOverlayPage.IsDisplayed());
            pauseOverlayPage.PressResume();
            Assert.True(gamePlayPage.IsDisplayed());
        }
        [Test]
        public void TestGamePausedAndStoppedCorrectly()
        {
            gamePlayPage.PressPause();
            pauseOverlayPage.PressMainMenu();
            Assert.True(mainMenuPage.IsDisplayed());
        }
        [Test]
        public void TestAvoiding5Obstacles()
        {
            gamePlayPage.AvoidObstacles(5);
            Assert.True(gamePlayPage.GetCurrentLife() > 0) ;
        }
        [Test]
        public void TestAvoiding10Obstacles()
        {
            gamePlayPage.AvoidObstacles(10);
            Assert.True(gamePlayPage.GetCurrentLife() > 0);
        }
        [Test]
        public void TestGameOver()
        {
            float timeout = 20;
            while (timeout > 0)
            {
                try
                {
                    getAnotherChancePage.IsDisplayed();
                    break;
                }
                catch (Exception)
                {
                    timeout -= 1;
                }
            }
            Assert.True(getAnotherChancePage.IsDisplayed());
        }

        [TearDown]
        public void Dispose()
        {
            altUnityDriver.Stop();
        }
    }
}