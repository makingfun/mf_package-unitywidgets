using NUnit.Framework;

namespace Makingfun.UnityWidgets.Editor.Tests
{
    public class ToolTipManagerTests
    {
        MockUIBase uiBaseMock;
        
        [SetUp]
        public void Setup() => uiBaseMock = new MockUIBase();

        [Test]
        public void ShowToolTip()
        {
            ToolTipManager.ShowText(uiBaseMock, string.Empty);
            Assert.IsTrue(uiBaseMock.ShowWasCalled);
        }

        [Test]
        public void ShowAfterDelay()
        {
            var mockTime = new MockTimeManager {delta = 1f};
            var timer = new Timer(mockTime, 5);

            ToolTipManager.ScheduleShowText(uiBaseMock, string.Empty, timer);
            
            TimePasses(timer, 5);
            
            Assert.IsTrue(uiBaseMock.ShowWasCalled);
        }

        [Test]
        public void NotShowIfDelayHasNotFinished()
        {
            var mockTime = new MockTimeManager {delta = 1f};
            const int expectedDuration = 5;
            var timer = new Timer(mockTime, expectedDuration);

            ToolTipManager.ScheduleShowText(uiBaseMock, string.Empty, timer);

            TimePasses(timer, expectedDuration - 1);
            
            Assert.IsFalse(uiBaseMock.ShowWasCalled);
        }

        [Test]
        public void ShowInDirectionRequested()
        {
            var mockTime = new MockTimeManager {delta = 1f};
            const int expectedDuration = 1;
            var timer = new Timer(mockTime, expectedDuration);
            const Direction expectedDirection = Direction.Up;
            
            ToolTipManager.ScheduleShowText(uiBaseMock, string.Empty, timer, expectedDirection);
            TimePasses(timer, expectedDuration);
            
            Assert.IsTrue(uiBaseMock.ShowWasCalled);
            Assert.AreEqual(expectedDirection, uiBaseMock.DirectionCalled);
        }

        static void TimePasses(Timer timer, float ticks)
        {
            for (var tick = 0; tick < ticks; ++tick)
                timer.Update();
        }
    }
}
