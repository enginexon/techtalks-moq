using Moq;
using MoqDemo.Tests.Logic;

namespace MoqDemo.Tests.LogicTests;

[TestFixture]
public class CompanyServiceMockRepositoryFailedTests
{
    [Test]
    public void GetByName_ShouldReturnNull()
    {
        var mockRepository = new Mock<ICompanyRepository>();
        var sut = new CompanyService(mockRepository.Object);
        var company = sut.GetByName(string.Empty);
        Assert.That(company, Is.Null);
    }
    
    [Test]
    public async Task GetByNameAsync_ShouldReturnNull()
    {
        var mockRepository = new Mock<ICompanyRepository>();
        var sut = new CompanyService(mockRepository.Object);
        var company = await sut.GetByNameAsync(string.Empty);
        Assert.That(company, Is.Null);
    }
}