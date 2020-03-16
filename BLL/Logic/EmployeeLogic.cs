using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.ViewModels;
using DAL.UnitWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Logic
{
    public class EmployeeLogic
    {
        private IUnitWork _unitWork;
        private IMapper _mapper;

        public EmployeeLogic(IMapper mapper)
        {
            _unitWork = new UnitWork();
            _mapper = mapper;
        }

        public IEnumerable<EmployeeVM> GetEmployees()
        {
            try
            {
                return _mapper.Map<List<EmployeeVM>>(_unitWork.Employee.Get());
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
