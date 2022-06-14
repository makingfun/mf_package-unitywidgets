namespace Makingfun.UnityWidgets
{
    public class ToolTipManager
    {
        readonly TimeManager timeManager;

        public ToolTipManager(TimeManager timeManager) => this.timeManager = timeManager;

        public static void ShowText(ToolTipUIBase uiBase, string message)
        {
            uiBase.SetMessage(message);
            uiBase.Show();
        }

        public static void ShowText(ToolTipUIBase uiBase, string message, Timer timer)
        {
            uiBase.SetMessage(message);
            timer.Expired += uiBase.Show;
            timer.Start();
        }
    }
}