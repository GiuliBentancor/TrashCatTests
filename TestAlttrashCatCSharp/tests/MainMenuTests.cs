using Altom.AltUnityDriver;
using TestAltTrashCatCSharp.pages;
using NUnit.Framework;

namespace TestAltTrashCatCSharp.tests
{

    public class MainMenuTests
    {
        private MainMenuPage mainMenuPage;
        private AltUnityDriver altUnityDriver;

        [SetUp]
        public void SetUp()
        {
            altUnityDriver = new AltUnityDriver(port: 13000);
            mainMenuPage = new MainMenuPage(altUnityDriver);
            mainMenuPage.LoadScene();
        }

        [TearDown]
        public void Dispose()
        {
            altUnityDriver.Stop();
        }


        [Test]
        public void TestMainMenuPageLoadedCorrectly()
        {
            Assert.True(mainMenuPage.IsDisplayed());
        }

    }

}