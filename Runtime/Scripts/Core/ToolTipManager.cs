namespace Makingfun.UnityWidgets
{
    public static class ToolTipManager
    {
        public static void ShowText(ToolTipUIBase uiBase, string message) => uiBase.Show(message);

        public static void ScheduleShowText(ToolTipUIBase uiBase, string message, Timer timer)
        {
            timer.Expired += () => uiBase.Show(message);
            timer.Start();
        }

        public static void ScheduleShowText(ToolTipUIBase uiBase, string message, Timer timer, Direction direction)
        {
            timer.Expired += () => uiBase.ShowWithDirection(message, direction);
            timer.Start();
        }
    }
}