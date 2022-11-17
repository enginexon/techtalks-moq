namespace MoqDemo.Tests.Logic;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _repository;

    public CompanyService(ICompanyRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    
    public Company? GetByName(string name)
    {
        return _repository.GetByName(name);
    }

    public Task<Company?> GetByNameAsync(string name)
    {
        return _repository.GetByNameAsync(name);
    }

    public Company? GetByNameUsingOut(string name)
    {
        _repository.GetByNameOut(name, out var companyResult);
        return companyResult?.Company;
    }

    public Company? GetByNameUsingRef(string name)
    {
        var companyResult = new CompanyResult();
        _repository.GetByNameRef(name, ref companyResult);
        return companyResult?.Company;
    }
}