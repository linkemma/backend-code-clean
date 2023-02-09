using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Entities.Interfaces;
using Tienda.Entities.POCOEntities;
using Tienda.Repositories.EFCore.DataContext;

namespace Tienda.Repositories.EFCore.Repositories
{
    public class OrderDetailRepository: IOrderDetailRepository
    {
        readonly TiendaContext _context;
        public OrderDetailRepository(TiendaContext context)
        {
            _context = context;
        }

        public void Create(OrderDetail orderDetail)
        {
            _context.Add(orderDetail);
        }
    }
}
