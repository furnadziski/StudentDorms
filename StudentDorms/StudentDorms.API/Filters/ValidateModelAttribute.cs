using StudentDorms.Common.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDorms.API.Filters
{
    public class ValidateModelAttribute : Attribute, IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values
                    .SelectMany(modelState => modelState.Errors)
                    .Select(modelError => modelError.ErrorMessage);

                throw new InvalidModelStateException(context.ModelState);
            }

            await next();
        }
    }
}
