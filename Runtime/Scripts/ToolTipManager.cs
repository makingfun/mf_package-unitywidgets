namespace Makingfun.UnityWidgets
{
    public class ToolTipManager
    {
        readonly TimeManager timeManager;

        public ToolTipManager(TimeManager timeManager) => this.timeManager = timeManager;

        public void ShowText(ToolTipUIBase uiBase, string message, float timeInSeconds = 0)
        {
            uiBase.SetMessage(message);
            
            var timer = new Timer(timeManager, timeInSeconds);
            timer.Expired += uiBase.Show;
            timer.Start();
        }
    }
}