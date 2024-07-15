using StudentDorms.Common.Exceptions;
using StudentDorms.Models.Enums;
using log4net;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace StudentDorms.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private static readonly ILog log = LogManager.GetLogger(Assembly.GetEntryAssembly(), "RollingFileAppenderName");
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            if (ex is StudentDormsException)
            {
                return Error(context, (ex as StudentDormsException).Message, (int)ErrorStatusCodeEnum.StudentDormsError);
            }

            if (ex is TokenNotValidException)
            {

                return Error(context, "Пратениот токен не е валиден", (int)ErrorStatusCodeEnum.TokenNotValid);
            }

            if (ex is TokenExpiredException)
            {
                return Error(context, "Пратениот токен е истечен", (int)ErrorStatusCodeEnum.TokenExpired);
            }

            if (ex is UnauthorizedAccessException)
            {
                return Error(context, "Неавторизиран пристап", (int)ErrorStatusCodeEnum.Unauthorized);
            }

            if (ex is ApplicationException)
            {
                return Error(context, "Системска грешка", (int)ErrorStatusCodeEnum.InternalServerError);
            }

            if (ex is NotImplementedException)
            {
                return Error(context, "Не постои имплементација", (int)ErrorStatusCodeEnum.NotImplemented);
            }

            if (ex is UserNotActiveException)
            {
                return Error(context, "Регистрираниот корисник е привремено оневозможен.", (int)ErrorStatusCodeEnum.UserNotActive);
            }

            if (ex is UserNotRegisteredException)
            {
                return Error(context, "Корисникот не е регистриран", (int)ErrorStatusCodeEnum.UserNotRegistered);
            }

            return Error(context, "Системска грешка", (int)ErrorStatusCodeEnum.InternalServerError);
        }

        private static Task Error(HttpContext context, string message, int code, bool formatMessage = true)
        {
            if (formatMessage)
            {
                message = FormatErrorMessage(message);
            }

            var result = JsonConvert.SerializeObject(new { error = message });
            context.Response.HttpContext.Features.Get<Microsoft.AspNetCore.Http.Features.IHttpResponseFeature>().ReasonPhrase = JsonConvert.SerializeObject(message);
            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.StatusCode = code;

            context.Response.HttpContext.Features.Get<Microsoft.AspNetCore.Http.Features.IHttpResponseFeature>().ReasonPhrase = result;

            return context.Response.WriteAsync(result);

        }

        private static string FormatErrorMessage(string message)
        {
            return "{" + string.Format("\"Message\":\"{0}\"", message) + "}";
        }
    }
}
