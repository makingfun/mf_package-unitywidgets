using NUnit.Framework;

namespace Makingfun.UnityWidgets.Editor.Tests
{
    public class ToolTipManagerTests
    {
        [Test]
        public void CanShowText()
        {
            var uiBase = new MockUIBase();
            
            ToolTipManager.ShowText(uiBase, string.Empty);
            
            Assert.IsTrue(uiBase.ShowWasCalled);
        }
    }

    public static class ToolTipManager
    {
        public static void ShowText(ToolTipUIBase uiBase, string message)
        {
            uiBase.SetMessage(message);
            uiBase.Show();
        }
    }
}
