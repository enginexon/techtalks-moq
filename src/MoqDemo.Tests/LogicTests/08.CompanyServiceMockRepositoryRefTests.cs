using Moq;
using MoqDemo.Tests.Logic;

namespace MoqDemo.Tests.LogicTests;

[TestFixture]
public class CompanyServiceMockRepositoryRefTests
{
    [Test]
    public void GetByNameUsingRef_ShouldWork()
    {
        var mockCompany = new Company()
        {
            Name = "FlixBus"
        };
        var companyResultRef = new CompanyResult()
        {
            Company = mockCompany
        };
        var mockRepository = new Mock<ICompanyRepository>();
        mockRepository
            .Setup(x => x.GetByNameRef(mockCompany.Name, ref It.Ref<CompanyResult>.IsAny))
            .Callback(new GetByNameRefCallback((string name, ref CompanyResult result) => result = companyResultRef));
        
        var sut = new CompanyService(mockRepository.Object);
        var company = sut.GetByNameUsingRef(mockCompany.Name);
        Assert.That(company, Is.Not.Null);
    }
    
    delegate void GetByNameRefCallback(string name, ref CompanyResult companyResult);
}