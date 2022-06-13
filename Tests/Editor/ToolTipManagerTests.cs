using NUnit.Framework;

namespace Makingfun.UnityWidgets.Editor.Tests
{
    public class ToolTipManagerTests
    {
        [Test]
        public void ShowText()
        {
            var uiBase = new MockUIBase();
            var mockTime = new MockTimeManager {delta = 1f};
            var tooltipManager = new ToolTipManager(mockTime);
            
            tooltipManager.ShowText(uiBase, string.Empty);
            
            Assert.IsTrue(uiBase.ShowWasCalled);
        }

        [Test]
        public void ShowTextAfterDelay()
        {
            var uiBase = new MockUIBase();
            var mockTime = new MockTimeManager {delta = 1f};
            var tooltipManager = new ToolTipManager(mockTime);
            //
            // var timer = new Timer(mockTime, 5);
            // timer.Expired += uiBase.Show;

            //When
            tooltipManager.ShowText(uiBase, string.Empty, 5);
            
            // TimePasses(timer, 5);
            
            Assert.IsTrue(uiBase.ShowWasCalled);
        }

        static void TimePasses(Timer timer, float ticks)
        {
            for (var tick = 0; tick < ticks; ++tick)
                timer.Update();
        }
    }
}
