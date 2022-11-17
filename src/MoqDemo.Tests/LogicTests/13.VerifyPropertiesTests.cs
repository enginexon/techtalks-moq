using Moq;
using MoqDemo.Tests.Logic;

namespace MoqDemo.Tests.LogicTests;

[TestFixture]
public class VerifyPropertiesTests
{
    [Test]
    public void VerifyGet_ShouldWork()
    {
        const int overallScore = 10;
        var mockCompanyResult = new Mock<CompanyResult>();
        mockCompanyResult.SetupProperty(x => x.Company.Rating.OverallScore, overallScore);

        // emulate reading
        var realOverallScore = mockCompanyResult.Object?.Company?.Rating?.OverallScore;
        Assert.That(realOverallScore, Is.EqualTo(overallScore));
        
        mockCompanyResult.VerifyGet(x => x.Company.Rating.OverallScore);
        mockCompanyResult.VerifyGet(x => x.Company.Rating.OverallScore, Times.Once);
        mockCompanyResult.VerifyGet(x => x.Company.Rating.OverallScore, Times.AtLeastOnce);
    }
    
    [Test]
    public void VerifySet_ShouldWork()
    {
        const int overallScore = 10;
        var mockCompanyResult = new Mock<CompanyResult>();
        mockCompanyResult.SetupProperty(x => x.Company.Rating.OverallScore, overallScore);

        // emulate writing
        var newOverallScore = 11;
        mockCompanyResult.Object.Company.Rating.OverallScore = newOverallScore;
        Assert.That(mockCompanyResult.Object.Company.Rating.OverallScore, Is.EqualTo(newOverallScore));
        
        mockCompanyResult.VerifySet(x => x.Company.Rating.OverallScore);
        mockCompanyResult.VerifySet(x => x.Company.Rating.OverallScore = newOverallScore);
    }
}