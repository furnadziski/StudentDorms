using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace StudentDorms.Common.Exceptions
{
    [Serializable]
    public class InvalidModelStateException : Exception
    {
        public InvalidModelStateException(ModelStateDictionary modelState) : base(ModelStateExtensions.ToJson((object)new
        {
            Errors = ModelStateExtensions.Errors(modelState)
        }))
        {
        }
    }

    public class StudentDormsException : Exception
    {
        public StudentDormsException(string message) : base(message)
        {
        }
    }

    public class UserNotActiveException : Exception
    {
        public UserNotActiveException() : base()
        {
        }
    }

    public class UserNotRegisteredException : Exception
    {
        public UserNotRegisteredException() : base()
        {
        }
    }

    public class TokenNotValidException : Exception
    {
        public TokenNotValidException() : base()
        {
        }
    }

    public class TokenExpiredException : Exception
    {
        public TokenExpiredException() : base()
        {
        }
    }
}
