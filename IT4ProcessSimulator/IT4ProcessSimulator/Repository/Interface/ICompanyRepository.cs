using IT4ProcessSimulator.Models;

namespace IT4ProcessSimulator.Repository.Interface
{
    public interface ICompanyRepository
    {
        Task<List<CompanyModel>> GetAllCompany();
        Task<CompanyModel> GetCompanyById(int id);
        Task<CompanyModel> CreateCompany(CompanyModel company);
        Task<CompanyModel> UpdateCompanyById(CompanyModel company, int id);
        Task<bool> DeleteCompany(int id);


    }
}
