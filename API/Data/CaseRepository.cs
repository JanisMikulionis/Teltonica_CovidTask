using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace API.Data
{
    public class CaseRepository: iCaseRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CaseRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // public async Task<CaseDto> GetCaseAsync(string covidCase)
        // {
        //     return await _context.Cases
        //         .Where(x => x.Object_id == covidCase)
        //         .ProjectTo<CaseDto>(_mapper.ConfigurationProvider)
        //         .SingleOrDefaultAsync();
        // }

        public async Task<Case> GetCaseByIdAsync(int id)
        {
            return await _context.Cases.FindAsync(id);
        }

        public async Task<string> GetCaseGender(string covidCase)
        {
            return await _context.Cases
                .Where(x => x.Object_id == covidCase)
                .Select(x => x.Gender).FirstOrDefaultAsync();
        }
        public async Task<PagedList<CaseDto>> GetCasesAsync(CaseParams caseParams){
             var query = _context.Cases.AsQueryable();
             query = _context.Cases.AsNoTracking();

            return await PagedList<CaseDto>.CreateAsync(query.ProjectTo<CaseDto>(_mapper
                .ConfigurationProvider).AsNoTracking(), 
                    caseParams.PageNumber, caseParams.PageSize);
        }

        public void Update(Case covidCase)
        {
            _context.Entry(covidCase).State = EntityState.Modified;
        }
    }
}