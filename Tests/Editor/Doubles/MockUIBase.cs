namespace Makingfun.UnityWidgets.Editor.Tests
{
    public class MockUIBase : ToolTipUIBase
    {
        public bool ShowWasCalled;
        public Direction DirectionCalled { get; private set; }

        public void Show(string message) => ShowWasCalled = true;
        public void ShowWithDirection(string message, Direction direction)
        {
            ShowWasCalled = true;
            DirectionCalled = direction;
        }
    }
}