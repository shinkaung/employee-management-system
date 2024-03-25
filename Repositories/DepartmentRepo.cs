using System.Reflection;
using EMS.Data;
using EMS.Models;
using EMS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EMS.Repositories
{
    public class DepartmentRepo : Repository<Department>, IDepartmentRepo
    {
        /*** Properties ***/
        private readonly AppDbContext _db;

        /*** Constructor ***/
        public DepartmentRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }

        /*** Methods ***/
        public void Update(Department existingDepartment, Department newDepartment)
        {
            existingDepartment.DepartmentCode = newDepartment.DepartmentCode ?? existingDepartment.DepartmentCode;
            existingDepartment.DepartmentName = newDepartment.DepartmentName ?? existingDepartment.DepartmentName;
        }

        public async Task<int> GetTotalUnits(int id)
        {
            return await _db.Departments
                .Where(d => d.Id == id)
                .SelectMany(d => d.Units)
                .SelectMany(u => u.Employees)
                .CountAsync();
        }
    }
}