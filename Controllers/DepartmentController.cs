using AutoMapper;
using EMS.DTOs;
using EMS.Models;
using EMS.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    // [Authorize(Roles = "admin")]
    public class DepartmentController : Controller
    {
        /*** Properties ***/
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /*** Constructor ***/
        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /*** Methods ***/
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10
        )
        {
            try
            {
                var departments = await _unitOfWork.repoDepartment.GetAll(propsInclude: ["HeadOfDepartment"]);

                /* Pagination */
                // Input Limitation
                pageSize = Math.Min(50, pageSize);

                int totalRecords = departments.Count();
                int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

                // Clamped Value
                page = Math.Max(1, Math.Min(page, totalPages));

                departments = departments.Skip((page - 1) * pageSize).Take(pageSize);
                var departmentListDTOs = _mapper.Map<IEnumerable<DepartmentListDTO>>(departments);

                return Ok(new
                {
                    totalRecords = totalRecords,
                    totalPages = totalPages,
                    pageSize = pageSize,
                    data = departmentListDTOs
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal Server Error: {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            try
            {
                var department = await _unitOfWork.repoDepartment.Get(d => d.Id == id);
                if (department == null) return NotFound();

                var departmentDetailedDTO = _mapper.Map<DepartmentDetailedDTO>(department);
                return Ok(departmentDetailedDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal Server Error: {e.Message}");
            }
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetTotalDepartmentCount()
        {
            try
            {
                var departments = await _unitOfWork.repoDepartment.GetAll();
                int count = departments.Count();

                return Ok(new { totalDepartments = count });
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal Server Error: {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewDepartment(Department department)
        {
            try
            {
                await _unitOfWork.repoDepartment.Add(department);
                await _unitOfWork.Save();

                return CreatedAtAction(
                    nameof(GetDepartmentById),
                    new { id = department.Id },
                    department
                );
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal Server Error: {e.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, DepartmentUpdateDTO departmentUpdateDTO)
        {
            try
            {
                var existingDepartment = await _unitOfWork.repoDepartment.Get(d => d.Id == id);
                if (existingDepartment == null) return NotFound();

                var newDepartment = _mapper.Map<Department>(departmentUpdateDTO);
                _unitOfWork.repoDepartment.Update(existingDepartment, newDepartment);
                await _unitOfWork.Save();

                return await GetDepartmentById(id);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal Server Error: {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            try
            {
                var department = await _unitOfWork.repoDepartment.Get(e => e.Id == id);
                if (department == null) return NotFound();

                _unitOfWork.repoDepartment.Remove(department);
                await _unitOfWork.Save();

                return Ok(new { id });
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal Server Error: {e.Message}");
            }
        }

        [HttpGet("{id}/units")]
        public async Task<IActionResult> GetAllUnitsInDepartment(int id)
        {
            try
            {
                var department = await _unitOfWork.repoDepartment.Get(d => d.Id == id);
                if (department == null) return NotFound();

                var units = department.Units;
                var unitMinimalDTOs = _mapper.Map<IEnumerable<UnitMinimalDTO>>(units);

                return Ok(new
                {
                    data = unitMinimalDTOs
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal Server Error: {e.Message}");
            }
        }

        [HttpGet("{id}/employees")]
        public async Task<IActionResult> GetNumberOfEmployeesInDepartment(int id)
        {
            try
            {
                var count = await _unitOfWork.repoDepartment.GetTotalUnits(id);
                return Ok(new
                {
                    data = count
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal Server Error: {e.Message}");
            }
        }
    }
}