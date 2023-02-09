using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Entities.Interfaces;
using Tienda.Entities.POCOEntities;
using Tienda.Entities.Specifications;
using Tienda.Repositories.EFCore.DataContext;

namespace Tienda.Repositories.EFCore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        readonly TiendaContext _context;
        public OrderRepository(TiendaContext context)
        {
            _context = context;
        }

        public void Create(Order order)
        {
            _context.Add(order);
        }

        public IEnumerable<Order> GetOrdersBySpecification(Specification<Order> specification)
        {
            var ExpressionDelegate = specification.Expression.Compile();
            return _context.Orders.Where(ExpressionDelegate);
        }
    }
}
