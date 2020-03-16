using AutoMapper;
using DAL.UnitWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Logic
{
    public class Logic
    {
        protected IUnitWork _unitWork;
        protected IMapper _mapper;

        public Logic(IMapper mapper)
        {
            _unitWork = new UnitWork();
            _mapper = mapper;
        }

        public void Commit()
        {
            _unitWork.Commit();
        }
    }
}
