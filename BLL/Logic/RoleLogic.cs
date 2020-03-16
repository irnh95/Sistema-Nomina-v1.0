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
    public class RoleLogic : Logic
    {
        public RoleLogic(IMapper mapper) : base(mapper)
        {
        }

        public IEnumerable<RoleVM> GetRoles()
        {
            try
            {
                return _mapper.Map<List<RoleVM>>(_unitWork.Role.Get());
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
