using Moq;
using MoqDemo.Tests.Logic;

namespace MoqDemo.Tests.LogicTests;

[TestFixture]
public class CompanyServiceMockRepositoryFirstMockWithItIsAnyTests
{
    [Test]
    public void GetByName_ShouldWork()
    {
        var mockCompany = new Company()
        {
            Name = "FlixBus"
        };
        var mockRepository = new Mock<ICompanyRepository>();
        mockRepository.Setup(x => x.GetByName(It.IsAny<string>()))
            .Returns(mockCompany);
        
        var sut = new CompanyService(mockRepository.Object);
        var company = sut.GetByName(mockCompany.Name);
        Assert.That(company, Is.Not.Null);
    }
    
    [Test]
    public async Task GetByNameAsync_ShouldWork()
    {
        var mockCompany = new Company()
        {
            Name = "FlixBus"
        };
        var mockRepository = new Mock<ICompanyRepository>();
        mockRepository.Setup(x => x.GetByNameAsync(It.IsAny<string>()))
            .Returns(Task.FromResult<Company?>(mockCompany));
        
        var sut = new CompanyService(mockRepository.Object);
        var company = await sut.GetByNameAsync(mockCompany.Name);
        Assert.That(company, Is.Not.Null);
    }
}