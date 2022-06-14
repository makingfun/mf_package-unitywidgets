using NUnit.Framework;

namespace Makingfun.UnityWidgets.Editor.Tests
{
    public class ToolTipManagerTests
    {
        MockUIBase uiBase;
        
        [SetUp]
        public void Setup() => uiBase = new MockUIBase();

        [Test]
        public void ShowText()
        {
            uiBase = new MockUIBase();
            ToolTipManager.ShowText(uiBase, string.Empty);
            Assert.IsTrue(uiBase.ShowWasCalled);
        }

        [Test]
        public void ShowTextAfterDelay()
        {
            uiBase = new MockUIBase();
            var mockTime = new MockTimeManager {delta = 1f};
            var timer = new Timer(mockTime, 5);

            ToolTipManager.ScheduleShowText(uiBase, string.Empty, timer);
            
            TimePasses(timer, 5);
            
            Assert.IsTrue(uiBase.ShowWasCalled);
        }

        [Test]
        public void NotShowTextIfDelayHasNotFinished()
        {
            uiBase = new MockUIBase();
            var mockTime = new MockTimeManager {delta = 1f};
            const int expectedDuration = 5;
            var timer = new Timer(mockTime, expectedDuration);

            ToolTipManager.ScheduleShowText(uiBase, string.Empty, timer);

            TimePasses(timer, expectedDuration - 1);
            
            Assert.IsFalse(uiBase.ShowWasCalled);
        }

        static void TimePasses(Timer timer, float ticks)
        {
            for (var tick = 0; tick < ticks; ++tick)
                timer.Update();
        }
    }
}
