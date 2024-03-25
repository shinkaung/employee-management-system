using EMS.Data;
using EMS.Repositories.Interfaces;

namespace EMS.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        /*** Properties ***/
        private readonly AppDbContext _db;

        /*** Repositories(Properties) ***/
        public IEmployeeRepo repoEmployee { get; private set; }
        public IDepartmentRepo repoDepartment { get; private set; }
        public IUnitRepo repoUnit { get; private set; }

        /*** Constructor ***/
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            repoEmployee = new EmployeeRepo(_db);
            repoDepartment = new DepartmentRepo(_db);
            repoUnit = new UnitRepo(_db);
        }

        /*** Methods ***/
        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}