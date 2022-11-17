using Moq;
using MoqDemo.Tests.Logic;

namespace MoqDemo.Tests.LogicTests;

[TestFixture]
public class VerifyNoOtherCallsTests
{
    [Test]
    public void VerifyNoOtherCalls_ShouldWork()
    {
        const int overallScore = 10;
        var mockCompanyResult = new Mock<CompanyResult>();
        mockCompanyResult.SetupProperty(x => x.Company.Rating.OverallScore, overallScore);

        // emulate reading
        var realOverallScore = mockCompanyResult.Object?.Company?.Rating?.OverallScore;
        Assert.That(realOverallScore, Is.EqualTo(overallScore));
        
        mockCompanyResult.VerifyGet(x => x.Company.Rating.OverallScore);
        
        mockCompanyResult.VerifyNoOtherCalls();
    }
    
    [Test]
    public void VerifyNoOtherCalls_ShouldFail()
    {
        const string companyName = "FlixBus";
        const int overallScore = 10;
        var mockCompanyResult = new Mock<CompanyResult>();
        mockCompanyResult.SetupProperty(x => x.Company.Name, companyName);
        mockCompanyResult.SetupProperty(x => x.Company.Rating.OverallScore, overallScore);

        // emulate reading
        var realOverallScore = mockCompanyResult.Object?.Company?.Rating?.OverallScore;
        Assert.That(realOverallScore, Is.EqualTo(overallScore));
        
        // emulate reading Name
        var realCompanyName = mockCompanyResult.Object?.Company?.Name;
        
        mockCompanyResult.VerifyGet(x => x.Company.Rating.OverallScore);
        
        Assert.Throws<MockException>(() => mockCompanyResult.VerifyNoOtherCalls());
    }
}