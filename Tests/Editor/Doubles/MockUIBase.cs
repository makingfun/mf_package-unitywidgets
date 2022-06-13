namespace Makingfun.UnityWidgets.Editor.Tests
{
    public class MockUIBase : ToolTipUIBase
    {
        public bool ShowWasCalled;

        public void SetMessage(string message){ }

        public void Show() => ShowWasCalled = true;
    }
}