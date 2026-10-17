using FluentValidation;
using MediatR;

namespace Applcation.Behavior
{
    public class ValidtionBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
     where TResponse : notnull
    {


        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!validators.Any())
                return await next();
            var context = new ValidationContext<TRequest>(request);
            var validationResult =await Task.WhenAll(validators.Select(v => v.ValidateAsync(context,cancellationToken)));
            var failures = validationResult.SelectMany(r => r.Errors).Where(f => f != null).ToList();
            if (failures.Count != 0)
                throw new ValidationException(failures);
            return await next();
        }
    }
}
