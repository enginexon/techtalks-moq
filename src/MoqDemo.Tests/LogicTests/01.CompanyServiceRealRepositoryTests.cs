using MoqDemo.Tests.Logic;

namespace MoqDemo.Tests.LogicTests;

[TestFixture]
public class CompanyServiceRealRepositoryTests
{
    [Test]
    public void GetByName_ShouldWork()
    {
        var repository = new CompanyRepository();
        var sut = new CompanyService(repository);
        sut.GetByName(string.Empty);
    }
}