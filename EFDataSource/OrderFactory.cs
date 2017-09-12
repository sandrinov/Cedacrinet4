using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataSource
{
    public class OrderFactory
    {
        public CommonNet4.DTO.Order GetDTO(EFDataSource.Order entity)
        {
            CommonNet4.DTO.Order dto = new CommonNet4.DTO.Order();
            dto.OrderID = entity.OrderID;
            dto.ShipAddress = entity.ShipAddress;
            dto.ShipCity = entity.ShipCity;
            dto.ShipName = entity.ShipName;

            return dto;
        }
    }
}
