using EMS.Models;

namespace EMS.Repositories.Interfaces
{
    public interface IEmployeeRepo : IRepository<Employee>
    {
        void Update(Employee existingEmployee, Employee newEmployee);
    }
}