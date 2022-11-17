using Moq;
using MoqDemo.Tests.Logic;

namespace MoqDemo.Tests.LogicTests;

[TestFixture]
public class CompanyServiceMockRepositoryOutTests
{
    [Test]
    public void GetByNameOut_ShouldWork()
    {
        var mockCompany = new Company()
        {
            Name = "FlixBus"
        };
        var companyResultOut = new CompanyResult()
        {
            Company = mockCompany
        };
        var mockRepository = new Mock<ICompanyRepository>();
        mockRepository.Setup(x => x.GetByNameOut(mockCompany.Name, out companyResultOut));
        
        var sut = new CompanyService(mockRepository.Object);
        var company = sut.GetByNameUsingOut(mockCompany.Name);
        Assert.That(company, Is.Not.Null);
    }
}