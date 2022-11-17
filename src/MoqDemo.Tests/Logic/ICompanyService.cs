namespace MoqDemo.Tests.Logic;

public interface ICompanyService
{
    Company? GetByName(string name);
    Task<Company?> GetByNameAsync(string name);
    
    Company? GetByNameUsingOut(string name);
    Company? GetByNameUsingRef(string name);
}