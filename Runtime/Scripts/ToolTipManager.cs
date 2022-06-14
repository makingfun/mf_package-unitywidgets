namespace Makingfun.UnityWidgets
{
    public static class ToolTipManager
    {
        public static void ShowText(ToolTipUIBase uiBase, string message)
        {
            uiBase.SetMessage(message);
            uiBase.Show();
        }

        public static void ScheduleShowText(ToolTipUIBase uiBase, string message, Timer timer)
        {
            uiBase.SetMessage(message);
            timer.Expired += uiBase.Show;
            timer.Start();
        }
    }
}