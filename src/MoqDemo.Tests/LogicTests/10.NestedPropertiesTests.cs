using Moq;
using MoqDemo.Tests.Logic;

namespace MoqDemo.Tests.LogicTests;

[TestFixture]
public class NestedPropertiesTests
{
    [Test]
    public void SetupProperty_ShouldWork()
    {
        const int overallScore = 10;
        var mockCompanyResult = new Mock<CompanyResult>();
        mockCompanyResult.SetupProperty(x => x.Company.Rating.OverallScore, overallScore);

        Assert.That(mockCompanyResult.Object?.Company?.Rating?.OverallScore, Is.EqualTo(overallScore));
    }
}