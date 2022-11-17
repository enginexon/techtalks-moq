namespace MoqDemo.Tests.Logic;

public interface ICompanyRepository
{
    Company? GetByName(string name);
    Task<Company?> GetByNameAsync(string name);
    void GetByNameOut(string name, out CompanyResult companyResult);
    void GetByNameRef(string name, ref CompanyResult companyResult);
}

public class CompanyRepository : ICompanyRepository
{
    private const string ExceptionMessage = "Invalid connection string!";
    
    public Company? GetByName(string name)
    {
        throw new Exception(ExceptionMessage);
    }

    public Task<Company?> GetByNameAsync(string name)
    {
        throw new Exception(ExceptionMessage);
    }

    public void GetByNameOut(string name, out CompanyResult companyResult)
    {
        throw new Exception(ExceptionMessage);
    }

    public void GetByNameRef(string name, ref CompanyResult companyResult)
    {
        throw new Exception(ExceptionMessage);
    }
}