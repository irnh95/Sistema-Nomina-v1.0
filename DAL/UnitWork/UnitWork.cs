using DAL.Data;
using DAL.Repository;

namespace DAL.UnitWork
{
    /// <summary>
    /// adding the unit work pattern
    /// </summary>
    public class UnitWork : IUnitWork
    {

        private ApplicationDbContext _dbContext;
        private EmployeeRepo _employee;
        private EmployeeRoleRepo _employeeRole;
        private RoleRepo _role;


        public UnitWork()
        {
            _dbContext = new ApplicationDbContext(ApplicationDbContext.optionsBuild.options);
        }
        public UnitWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public EmployeeRepo Employee
        {
            get
            {
                return _employee ??
                    (_employee = new EmployeeRepo(_dbContext));
            }
        }

        public EmployeeRoleRepo EmployeeRole
        {
            get
            {
                return _employeeRole ??
                    (_employeeRole = new EmployeeRoleRepo(_dbContext));
            }
        }

        public RoleRepo Role
        {
            get
            {
                return _role ??
                    (_role = new RoleRepo(_dbContext));
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
