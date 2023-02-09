using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Entities.POCOEntities;
using Tienda.Entities.Specifications;

namespace Tienda.Entities.Interfaces
{
    public interface IOrderRepository
    {
        void Create(Order order);
        IEnumerable<Order> GetOrdersBySpecification(Specification<Order> specification);
    }
}
