using AutoMapper;
using EMS.DTOs;
using EMS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controllers
{
    [ApiController]
    [Route("/api/{controller}")]
    public class UnitController : Controller
    {
        /*** Properties ***/
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /*** Constructor ***/
        public UnitController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /*** Methods ***/
        [HttpGet]
        public async Task<IActionResult> GetAllUnits(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10
        )
        {
            try
            {
                var units = await _unitOfWork.repoUnit.GetAll();

                /* Pagination */
                // Input Limitation
                pageSize = Math.Min(50, pageSize);

                int totalRecords = units.Count();
                int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

                // Clamped Value
                page = Math.Max(1, Math.Min(page, totalPages));

                units = units.Skip((page - 1) * pageSize).Take(pageSize);
                var unitReadDTOs = _mapper.Map<IEnumerable<UnitListDTO>>(units);

                return Ok(new
                {
                    totalRecords = totalRecords,
                    totalPages = totalPages,
                    pageSize = pageSize,
                    data = unitReadDTOs
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal Server Error: {e.Message}");
            }
        }
    }
}