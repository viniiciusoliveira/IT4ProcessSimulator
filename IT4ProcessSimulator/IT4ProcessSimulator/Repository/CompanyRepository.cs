using IT4ProcessSimulator.DataBase;
using IT4ProcessSimulator.Models;
using IT4ProcessSimulator.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace IT4ProcessSimulator.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DbContextIT4ProcessSimulator _connetion;
        public CompanyRepository(DbContextIT4ProcessSimulator connetion)
        {
            _connetion = connetion;
        }
        public async Task<List<CompanyModel>> GetAllCompany()
        {
             return await _connetion.Company.ToListAsync();     
        }

        public async Task<CompanyModel> GetCompanyById(int id)
        {
            return await _connetion.Company.FirstOrDefaultAsync(x => x.Id == id);         
        }

        public async Task<CompanyModel> UpdateCompanyById(CompanyModel company, int id)
        {
            CompanyModel _company = await GetCompanyById(id);

            if(_company == null)
            {
                throw new Exception($"Não foi encontrado nenhuma company para o id: {id}");
            }

            _company.Nome = company.Nome;
            _company.Email = company.Email;
            _company.Telefone = company.Telefone;

            _connetion.Company.Update(_company);
            await _connetion.SaveChangesAsync();

            return _company;
        }
        public async Task<bool> DeleteCompany(int id)
        {
            CompanyModel _company = await GetCompanyById(id);

            if (_company == null)
            {
                throw new Exception($"Não foi encontrado nenhuma company para o id: {id}");
            }

            _connetion.Company.Remove(_company);
            await _connetion.SaveChangesAsync();   

            return true;
        }

        public async Task<CompanyModel> CreateCompany(CompanyModel company)
        {
            await _connetion.Company.AddAsync(company);
            await _connetion.SaveChangesAsync();

            return company;
        }
    }
}
