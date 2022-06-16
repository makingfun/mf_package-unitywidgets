namespace Makingfun.UnityWidgets
{
    public interface ToolTipUIBase
    {
        void Show(string message);
        
        void ShowWithDirection(string message, Direction direction);

        void Hide();
    }
}