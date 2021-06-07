using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO;
using API.Extensions;
using API.Helpers;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace API.Controllers
{
    public class CasesController: BaseApiController
    {
        private readonly iCaseRepository _caseRepository;
        private readonly IMapper _mapper;
        public CasesController(iCaseRepository caseRepository, IMapper mapper)
        {
            _caseRepository = caseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaseDto>>> GetCases([FromQuery] CaseParams caseParams)
        {
            var cases = await _caseRepository.GetCasesAsync(caseParams);
            Response.AddPaginationHeader(cases.CurrentPage, cases.PageSize, 
            cases.TotalCount, cases.TotalPages);

            return Ok(cases);
        }
    }
}