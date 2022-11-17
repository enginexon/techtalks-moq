using Moq;
using MoqDemo.Tests.Logic;

namespace MoqDemo.Tests.LogicTests;

[TestFixture]
public class CompanyServiceMockRepositoryPropertiesTests
{
    [Test]
    public void GetByName_ShouldWork()
    {
        const string companyName = "FlixBus";
        var mockCompany = new Mock<Company>();
        mockCompany.Setup(x => x.Name).Returns(companyName);
        var mockRepository = new Mock<ICompanyRepository>();
        mockRepository.Setup(x => x.GetByName(companyName))
            .Returns(mockCompany.Object);
        
        var sut = new CompanyService(mockRepository.Object);
        var company = sut.GetByName(companyName);
        Assert.That(company, Is.Not.Null);
        Assert.That(company?.Name, Is.EqualTo(companyName));
    }
    
    [Test]
    public void GetByName2_ShouldWork()
    {
        const string companyName = "FlixBus";
        var mockCompany = new Mock<Company>();
        mockCompany.SetupProperty(x => x.Name, companyName);
        var mockRepository = new Mock<ICompanyRepository>();
        mockRepository.Setup(x => x.GetByName(companyName))
            .Returns(mockCompany.Object);
        
        var sut = new CompanyService(mockRepository.Object);
        var company = sut.GetByName(companyName);
        Assert.That(company, Is.Not.Null);
        Assert.That(company?.Name, Is.EqualTo(companyName));
    }
}