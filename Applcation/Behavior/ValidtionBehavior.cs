using FluentValidation;
using MediatR;

namespace Applcation.Behavior
{
    public class ValidtionBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
     where TResponse : notnull
    {


        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!validators.Any())
                return next();
            var context = new ValidationContext<TRequest>(request);
            var validationResult = validators.Select(v => v.Validate(context));
            var failures = validationResult.SelectMany(r => r.Errors).Where(f => f != null).ToList();
            if (failures.Count != 0)
                throw new ValidationException(failures);
            return next(cancellationToken);
        }
    }
}
