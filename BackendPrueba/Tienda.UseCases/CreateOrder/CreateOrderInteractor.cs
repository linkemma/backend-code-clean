using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Entities.Exceptions;
using Tienda.Entities.Interfaces;
using Tienda.Entities.POCOEntities;

namespace Tienda.UseCases.CreateOrder
{
    public class CreateOrderInteractor : IRequestHandler<CreateOrderInputPort, int>
    {
        readonly IOrderRepository _orderRepository;
        readonly IOrderDetailRepository _orderDetailRepository;
        readonly IUnitiOfWork _unitiOfWork;

        public CreateOrderInteractor(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IUnitiOfWork unitiOfWork)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _unitiOfWork = unitiOfWork;
        }

        public async Task<int> Handle(CreateOrderInputPort request, CancellationToken cancellationToken)
        {
            Order Order = new Order
            {
                CustomerId = request.CustumerId,
                OrderDate = DateTime.Now
            };
            _orderRepository.Create(Order);
            foreach(var Item in request.OrderDetails)
            {
                _orderDetailRepository.Create(
                    new OrderDetail
                    {
                        Order = Order,
                        ProductId = Item.ProductoId,
                        UnitPrice = Item.UniPrice,
                        Quantity = Item.Quantity
                    });
            }
            try
            {
                await _unitiOfWork.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new GeneralException("Error al crear la orden. ", ex.Message);
            }
            return Order.Id;

        }
    }
}
