using Altom.AltUnityDriver;

namespace TestAltTrashCatCSharp.pages
{
    public class LeaderBoardPage : BasePage
    {
        public LeaderBoardPage(AltUnityDriver driver) : base(driver)
        {
        }

        public AltUnityObject LeaderboardDisplayScore { get => Driver.WaitForObject(By.NAME, "UICamera/Leaderboard//Display/Score", timeout: 5); }
        public AltUnityObject LeaderboardButton { get => Driver.WaitForObject(By.NAME, "UICamera/Leaderboard//Button", timeout: 2); }

        public bool IsDisplayed()
        {
            if (LeaderboardDisplayScore != null && LeaderboardButton != null)
                return true;
            return false;
        }
        public void PressLeaderboardButton()
        {
            LeaderboardButton.Tap();
        }
    }
}