using MoqDemo.Tests.Logic;

namespace MoqDemo.Tests.LogicTests;

[TestFixture]
public class CompanyServiceConstructionTests
{
    [Test]
    public void Constructor_ShouldWork()
    {
        var sut = new CompanyService(null);
    }
}