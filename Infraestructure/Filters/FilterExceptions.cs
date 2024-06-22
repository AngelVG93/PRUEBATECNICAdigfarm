using Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;


namespace Infraestructure.Filters
{
    public class FilterExceptions : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            HttpStatusCode Status = HttpStatusCode.InternalServerError;
            string Title = string.Empty;
            string Detail = string.Empty;


            if (context.Exception.GetType() == typeof(InternalServerErrorBusinessExceprions)) {
                var exception = (InternalServerErrorBusinessExceprions)context.Exception;
                Status = HttpStatusCode.InternalServerError;
                Title = !string.IsNullOrEmpty(exception.exception.Name) ? $"Internal Server Error {exception.exception.Name}" : $"Not name";
                Detail = !string.IsNullOrEmpty(exception.exception.Message) ? exception.exception.Message : exception.Message;
            }
            if (context.Exception.GetType() == typeof(BadRequestBusinessException))
            {
                var exception = (BadRequestBusinessException)context.Exception;
                Status = HttpStatusCode.BadRequest;
                Title = !string.IsNullOrEmpty(exception.exception.Name) ? $"BadRequest Server Error {exception.exception.Name}" : $"Not name";
                Detail = !string.IsNullOrEmpty(exception.exception.Message) ? exception.exception.Message : exception.Message;
            }
            if (context.Exception.GetType() == typeof(NotFoundException))
            {
                var exception = (NotFoundException)context.Exception;
                Status = HttpStatusCode.NotFound;

                Title = !string.IsNullOrEmpty(exception.exception.Name) ? $"NotFoundException Error {exception.exception.Name}" : $"Not name";
                Detail = !string.IsNullOrEmpty(exception.exception.Message) ? exception.exception.Message : exception.Message;
            }
            var objectException = new
            {
                Status,
                Title,
                Detail
            };

            var json = new
            {
                errors = new[] { objectException }
            };
            context.Result = new JsonResult(json);
            context.HttpContext.Response.StatusCode = (int)Status;
            context.ExceptionHandled = true;
        }
    }
}
