using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.UseCases.Common.Bahaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        readonly IEnumerable<IValidator<TRequest>> _validator;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
        {
            _validator = validator;
        }

        public Task<TResponse> Handle(TRequest request, 
            RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var Failures = _validator.Select(v => v.Validate(request))
                                     .SelectMany(r => r.Errors)
                                     .Where(f => f != null)
                                     .ToList();
            if (Failures.Any())
            {
                throw new ValidationException(Failures);
            }
            return next();
        }
    }
}
