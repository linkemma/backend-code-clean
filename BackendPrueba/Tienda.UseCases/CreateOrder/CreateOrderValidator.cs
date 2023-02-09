using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.UseCases.CreateOrder
{
    public class CreateOrderValidator: AbstractValidator<CreateOrderInputPort>
    {
        public CreateOrderValidator()
        {
            RuleFor(c => c.CustumerId)
                    .NotEmpty()
                    .WithMessage("Debe ingresar el identificador del Cliente");
            RuleFor(c => c.OrderDetails)
                    .Must(d => d != null && d.Any())
                    .WithMessage("Debe Agregar productos al detalle");
        }
    }
}
