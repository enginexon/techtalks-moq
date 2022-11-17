using Moq;
using MoqDemo.Tests.Logic;

namespace MoqDemo.Tests.LogicTests;

[TestFixture]
public class CompanyServiceMockRepositoryTests
{
    [Test]
    public void GetByName_ShouldWork()
    {
        var mockRepository = new Mock<ICompanyRepository>();
        var sut = new CompanyService(mockRepository.Object);
        sut.GetByName(string.Empty);
    }
    
    [Test]
    public Task GetByNameAsync_ShouldWork()
    {
        var mockRepository = new Mock<ICompanyRepository>();
        var sut = new CompanyService(mockRepository.Object);
        return sut.GetByNameAsync(string.Empty);
    }
}