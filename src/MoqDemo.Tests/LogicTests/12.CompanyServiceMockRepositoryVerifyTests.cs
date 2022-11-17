using Moq;
using MoqDemo.Tests.Logic;

namespace MoqDemo.Tests.LogicTests;

[TestFixture]
public class CompanyServiceMockRepositoryVerifyTests
{
    [Test]
    public void GetByName_ShouldWork()
    {
        var mockCompany = new Company()
        {
            Name = "FlixBus"
        };
        var mockRepository = new Mock<ICompanyRepository>();
        mockRepository.Setup(x => x.GetByName(mockCompany.Name))
            .Returns(mockCompany);
        
        var sut = new CompanyService(mockRepository.Object);
        var company = sut.GetByName(mockCompany.Name);
        Assert.That(company, Is.Not.Null);
        
        mockRepository.Verify(x => x.GetByName(mockCompany.Name));
        mockRepository.Verify(x => x.GetByName(mockCompany.Name), Times.Once);
        mockRepository.Verify(x => x.GetByName(It.IsAny<string>()), Times.AtLeastOnce);
    }
}