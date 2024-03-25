using EMS.Models;

namespace EMS.Repositories.Interfaces
{
    public interface IDepartmentRepo : IRepository<Department>
    {
        void Update(Department existingDepartment, Department newDepartment);
        Task<int> GetTotalUnits(int id);
    }
}