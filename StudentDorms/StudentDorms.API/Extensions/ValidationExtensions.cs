using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.API.Extensions
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
