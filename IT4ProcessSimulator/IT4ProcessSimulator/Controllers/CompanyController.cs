using IT4ProcessSimulator.Models;
using IT4ProcessSimulator.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT4ProcessSimulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;


        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyModel>>> GetAllCompanies()
        {
           return await _companyRepository.GetAllCompany();
        }

        [HttpGet("id")]
        public async Task<ActionResult<CompanyModel>> GetCompanyById(int id)
        {
            return await _companyRepository.GetCompanyById(id);
        }

        [HttpPost]
        public async Task<ActionResult<CompanyModel>> CreateNewCompany([FromBody] CompanyModel company)
        {
            return await _companyRepository.CreateCompany(company);
        }

        [HttpPut]
        public async Task<ActionResult<CompanyModel>> UpdateCompanyById(CompanyModel companies, int id)
        {
            companies.Id = id; 
            CompanyModel company = await _companyRepository.UpdateCompanyById(companies, id);
            return Ok(company);
        }

        [HttpDelete]

        public async Task<ActionResult<bool>> DeleteCompany(int id)
        {
            bool delete = await _companyRepository.DeleteCompany(id);
            return Ok(delete);
        }
    }
}
