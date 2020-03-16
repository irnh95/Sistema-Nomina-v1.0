using DAL.Repository;

namespace DAL.UnitWork
{
    public interface IUnitWork
    {

        EmployeeRepo Employee { get; }
        EmployeeRoleRepo EmployeeRole { get; }
        void Commit();
    }
}
