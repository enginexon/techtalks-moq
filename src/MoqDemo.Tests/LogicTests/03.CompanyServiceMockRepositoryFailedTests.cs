using Moq;
using MoqDemo.Tests.Logic;

namespace MoqDemo.Tests.LogicTests;

[TestFixture]
public class CompanyServiceMockRepositoryFailedTests
{
    [Test]
    public void GetByName_ShouldWork()
    {
        var mockRepository = new Mock<ICompanyRepository>();
        var sut = new CompanyService(mockRepository.Object);
        var company = sut.GetByName(string.Empty);
        Assert.That(company, Is.Not.Null);
    }
    
    [Test]
    public async Task GetByNameAsync_ShouldWork()
    {
        var mockRepository = new Mock<ICompanyRepository>();
        var sut = new CompanyService(mockRepository.Object);
        var company = await sut.GetByNameAsync(string.Empty);
        Assert.That(company, Is.Not.Null);
    }
}