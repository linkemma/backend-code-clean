﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.UseCasesDTOs.CreateOrder;

namespace Tienda.UseCases.CreateOrder
{
    public class CreateOrderInputPort: CreateOrderParams, IRequest<int>
    {

    }
}
