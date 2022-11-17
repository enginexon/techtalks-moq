using MoqDemo.Tests.Logic;

namespace MoqDemo.Tests.LogicTests;

[TestFixture]
public class CompanyServiceConstructionTests
{
    [Test]
    public void Constructor_ShouldWork()
    {
        Assert.Throws<ArgumentNullException>(() => new CompanyService(null));
    }
}