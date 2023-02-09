using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.UseCasesDTOs.CreateOrder
{
    public class CreateOrderDetailsParams
    {
        public int ProductoId { get; set; }
        public decimal UniPrice { get; set; }
        public short Quantity { get; set; }
    }
}
