using System.Data.SqlTypes;
using Moq;
using MoqDemo.Tests.Logic;

namespace MoqDemo.Tests.LogicTests;

[TestFixture]
public class CompanyServiceMockRepositoryThrowExceptionTests
{
    [Test]
    public void GetByName_Should_ThrowException()
    {
        var mockCompany = new Company()
        {
            Name = "FlixBus"
        };
        var mockRepository = new Mock<ICompanyRepository>();
        mockRepository.Setup(x => x.GetByName(mockCompany.Name))
            .Throws<SqlTruncateException>();
        
        var sut = new CompanyService(mockRepository.Object);
        Assert.Throws<SqlTruncateException>(() => sut.GetByName(mockCompany.Name));
    }
    
    [Test]
    public void GetByName_Should_ThrowException2()
    {
        var mockCompany = new Company()
        {
            Name = "FlixBus"
        };
        var mockRepository = new Mock<ICompanyRepository>();
        mockRepository.Setup(x => x.GetByName(mockCompany.Name))
            .Throws(new SqlTruncateException());
        
        var sut = new CompanyService(mockRepository.Object);
        Assert.Throws<SqlTruncateException>(() => sut.GetByName(mockCompany.Name));
    }
}