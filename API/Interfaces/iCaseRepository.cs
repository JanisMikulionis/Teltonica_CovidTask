using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface iCaseRepository
    {
        void Update(Case covidCase);
        Task<Case> GetCaseByIdAsync(int id);
        Task<PagedList<CaseDto>> GetCasesAsync(CaseParams caseParams);
        //Task<CaseDto> GetCaseAsync(string covidCase);//
        Task<string> GetCaseGender(string covidCase);
    }
}