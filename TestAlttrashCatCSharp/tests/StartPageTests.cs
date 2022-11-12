using TestAltTrashCatCSharp.pages;
using NUnit.Framework;
using Altom.AltUnityDriver;

namespace TestAltTrashCatCSharp.tests
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
        public void TestStartLoadMainMenuCorrectly()
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