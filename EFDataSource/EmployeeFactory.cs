using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataSource
{
    public class EmployeeFactory
    {
        public CommonNet4.DTO.Employee GetDTO(EFDataSource.Employee entity)
        {
            CommonNet4.DTO.Employee dto = new CommonNet4.DTO.Employee();
            dto.EmployeeID = entity.EmployeeID;
            dto.FirstName = entity.FirstName;
            dto.LastName = entity.LastName;
            dto.City = entity.City;

            return dto;
        }
    }
}
