using EMS.Data;
using EMS.Models;
using EMS.Repositories.Interfaces;

namespace EMS.Repositories
{
    public class UnitRepo : Repository<Unit>, IUnitRepo
    {
        /*** Properties ***/
        private readonly AppDbContext _db;

        /*** Constructor ***/
        public UnitRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }

        /*** Methods ***/
        public void Update(Unit existingUnit, Unit newUnit)
        {
            existingUnit.UnitName = newUnit.UnitName ?? existingUnit.UnitName;
        }
    }
}