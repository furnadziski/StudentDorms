using System.Linq;

namespace CoMS.NUnitTesting.Extensions
{
    public static class ValidationExtensions
    {
        public static string GetModelErrors(FluentValidation.Results.ValidationResult modelState)
        {
            var errors = modelState.Errors.Select(x => x.ErrorMessage).ToList();
            return string.Join(",", errors);
        }
    }
}
