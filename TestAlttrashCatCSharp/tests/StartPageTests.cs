using alttrashcat_tests_csharp.pages;
using System.Threading;
using NUnit.Framework;
using Altom.AltUnityDriver;

namespace alttrashcat_tests_csharp.tests
{
    public class StartPageTests
    {
        private MainMenuPage mainMenuPage;
        private StartPage startPage;
        private AltUnityDriver altUnityDriver;


        [SetUp]
        public void SetupBeforeEachTest()
        {
            altUnityDriver = new AltUnityDriver(port: 13000);
            mainMenuPage = new MainMenuPage(altUnityDriver);
            mainMenuPage.LoadScene();
            startPage = new StartPage(altUnityDriver);
            startPage.Load();
            mainMenuPage = new MainMenuPage(altUnityDriver);
        }

        [Test]
        public void TestFirstPageLoadedCorrectly()
        {
            Assert.True(startPage.IsDisplayed());
        }

        [Test]
        public void TestStartButtonLoadMainMenu()
        {
            startPage.PressStart();
            Assert.True(mainMenuPage.IsDisplayed());
        }

        [TearDown]
        public void Dispose()
        {
            altUnityDriver.Stop();
        }
    }
}