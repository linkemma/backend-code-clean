using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.UseCasesDTOs.CreateOrder
{
    public class CreateOrderParams
    {
        public int CustumerId { get; set; }
        public List<CreateOrderDetailsParams> OrderDetails { get; set; }
    }
}
