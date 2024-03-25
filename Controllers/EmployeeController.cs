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
    public class EmployeeController : Controller
    {
        /*** Properties ***/
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /*** Constructor ***/
        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /*** Methods ***/
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 20
        )
        {
            try
            {
                var employees = await _unitOfWork.repoEmployee.GetAll();

                /* Pagination */
                // Input Limitation
                pageSize = Math.Min(50, pageSize);

                int totalRecords = employees.Count();
                int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

                // Clamped Value
                page = Math.Max(1, Math.Min(page, totalPages));

                employees = employees.Skip((page - 1) * pageSize).Take(pageSize);
                var employeeListDTOs = _mapper.Map<IEnumerable<EmployeeListDTO>>(employees);

                return Ok(new
                {
                    totalRecords = totalRecords,
                    totalPages = totalPages,
                    pageSize = pageSize,
                    data = employeeListDTOs
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal Server Error: {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _unitOfWork.repoEmployee.Get(e => e.Id == id);
                if (employee == null) return NotFound();

                var employeeDetailedDTO = _mapper.Map<EmployeeDetailedDTO>(employee);

                return Ok(employeeDetailedDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal Server Error: {e.Message}");
            }
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetTotalEmployeesCount()
        {
            try
            {
                var employees = await _unitOfWork.repoEmployee.GetAll();
                int count = employees.Count();

                return Ok(new { totalEmployees = count });
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal Server Error: {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewEmployee(Employee employee)
        {
            try
            {
                await _unitOfWork.repoEmployee.Add(employee);
                await _unitOfWork.Save();

                return CreatedAtAction(
                    nameof(GetEmployeeById),
                    new { id = employee.Id },
                    employee
                );
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal Server Error: {e.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeUpdateDTO employeeUpdateDTO)
        {
            try
            {
                var existingEmployee = await _unitOfWork.repoEmployee.Get(e => e.Id == id);
                if (existingEmployee == null) return NotFound();

                var newEmployee = _mapper.Map<Employee>(employeeUpdateDTO);
                _unitOfWork.repoEmployee.Update(existingEmployee, newEmployee);
                await _unitOfWork.Save();

                return await GetEmployeeById(id);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal Server Error: {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _unitOfWork.repoEmployee.Get(e => e.Id == id);
            if (employee == null) return NotFound();

            _unitOfWork.repoEmployee.Remove(employee);
            await _unitOfWork.Save();

            return Ok(new { id });
        }
    }
}