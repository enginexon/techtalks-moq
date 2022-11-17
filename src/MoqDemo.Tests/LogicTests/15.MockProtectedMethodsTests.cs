using Moq;
using Moq.Protected;
using MoqDemo.Tests.Logic;

namespace MoqDemo.Tests.LogicTests;

[TestFixture]
public class MockProtectedMethodsTests
{
    [Test]
    public void GetCurrentTime_ShouldWork()
    {
        var sut = new DateTimeNowProvider();
        var time = sut.GetCurrentTimeVirtual();
        Assert.That(time, Is.EqualTo(DateTime.Now).Within(1).Seconds);
    }
    
    [Test]
    public void Mock_GetCurrentTime_ShouldWork()
    {
        var mockTime = new DateTime(2022, 11, 17);
        var mockDateTimeNowProvider = new Mock<DateTimeNowProvider>();
        mockDateTimeNowProvider.Setup(x => x.GetCurrentTimeVirtual()).Returns(mockTime);
        
        var sut = mockDateTimeNowProvider.Object;
        var time = sut.GetCurrentTimeVirtual();
        Assert.That(time, Is.EqualTo(mockTime));
    }
    
    [Test]
    public void Mock_GetCurrentTimeInternal_ShouldWork()
    {
        var mockTime = new DateTime(2022, 11, 17);
        var mockDateTimeNowProvider = new Mock<DateTimeNowProvider>();
        mockDateTimeNowProvider
            .Protected()
            .Setup<DateTime>("GetCurrentTimeInternal")
            .Returns(mockTime);
        
        var sut = mockDateTimeNowProvider.Object;
        var time = sut.GetCurrentTime();
        Assert.That(time, Is.EqualTo(mockTime));
    }
    
    [Test]
    public void MockAsInterface_GetCurrentTimeInternal_ShouldWork()
    {
        var mockTime = new DateTime(2022, 11, 17);
        var mockDateTimeNowProvider = new Mock<DateTimeNowProvider>();
        mockDateTimeNowProvider
            .Protected()
            .As<IFakeDateTimeNowProvider>()
            .Setup(x => x.GetCurrentTimeInternal())
            .Returns(mockTime);
        
        var sut = mockDateTimeNowProvider.Object;
        var time = sut.GetCurrentTime();
        Assert.That(time, Is.EqualTo(mockTime));
    }
}

public class DateTimeNowProvider
{
    public virtual DateTime GetCurrentTimeVirtual()
    {
        return GetCurrentTimeInternal();
    }
    
    public DateTime GetCurrentTime()
    {
        return GetCurrentTimeInternal();
    }
    
    protected virtual DateTime GetCurrentTimeInternal()
    {
        return DateTime.Now;
    }
}

public interface IFakeDateTimeNowProvider
{
    DateTime GetCurrentTimeInternal();
}