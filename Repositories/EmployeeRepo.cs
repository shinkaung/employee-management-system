using AutoMapper;
using EMS.Data;
using EMS.Models;
using EMS.Repositories.Interfaces;

namespace EMS.Repositories
{
    public class EmployeeRepo : Repository<Employee>, IEmployeeRepo
    {
        /*** Properties ***/
        private readonly AppDbContext _db;

        /*** Constructor ***/
        public EmployeeRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }

        /*** Methods ***/
        public void Update(Employee existingEmployee, Employee newEmployee)
        {
            existingEmployee.FirstName = newEmployee.FirstName ?? existingEmployee.FirstName;
            existingEmployee.LastName = newEmployee.LastName ?? existingEmployee.LastName;
            existingEmployee.Email = newEmployee.Email ?? existingEmployee.Email;
            existingEmployee.Phone = newEmployee.Phone ?? existingEmployee.Phone;
            existingEmployee.Address = newEmployee.Address ?? existingEmployee.Address;
        }
    }
}