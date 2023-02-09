using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.WebExceptionsPresenter
{
    public class ApiExceptionFilterAttribute: ExceptionFilterAttribute
    {
        readonly IDictionary<Type, IExceptionHandler> _exceptionHandlers;

        public ApiExceptionFilterAttribute(IDictionary<Type, IExceptionHandler> exceptionHandlers)
        {
            _exceptionHandlers = exceptionHandlers;
        }

        public override void OnException(ExceptionContext context)
        {
            Type ExceptionType = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(ExceptionType))
            {
                _exceptionHandlers[ExceptionType].Handle(context);
            }
            else
            {
                new ExceptionHandlerBase().SetResult(context, 
                                            StatusCodes.Status500InternalServerError,
                                            "Ha ocurrido un error al procesar la respuesta.", "");
                base.OnException(context);
            }
        }
    }
}
