using EMS.Models;

namespace EMS.Repositories.Interfaces
{
    public interface IUnitRepo : IRepository<Unit>
    {
        void Update(Unit existingUnit, Unit newUnit);
    }
}