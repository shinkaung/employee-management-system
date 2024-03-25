namespace EMS.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        /* Repositories(Properties) */
        IEmployeeRepo repoEmployee { get; }
        IDepartmentRepo repoDepartment { get; }
        IUnitRepo repoUnit { get; }

        /* Methods */
        Task Save();
    }
}