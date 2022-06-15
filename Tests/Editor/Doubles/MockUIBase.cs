namespace Makingfun.UnityWidgets.Editor.Tests
{
    public class MockUIBase : ToolTipUIBase
    {
        public bool ShowWasCalled;
        public Direction DirectionCalled { get; private set; }

        public void SetMessage(string message){ }

        public void Show() => ShowWasCalled = true;
        public void ShowWithDirection(Direction direction)
        {
            ShowWasCalled = true;
            DirectionCalled = direction;
        }
    }
}