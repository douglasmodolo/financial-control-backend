using FinancialControl.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace FinancialControl.Api.Middleware
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode;
            string message;

            switch (exception)
            {
                case NotFoundException:
                    statusCode = HttpStatusCode.NotFound; // 404
                    message = "O recurso solicitado não foi encontrado.";
                    break;
                case ForbiddenAccessException:
                    statusCode = HttpStatusCode.Forbidden; // 403
                    message = "Você não tem permissão para executar esta ação.";
                    break;
                default:
                    statusCode = HttpStatusCode.InternalServerError; // 500
                    message = "Ocorreu um erro inesperado no servidor. Tente novamente mais tarde.";
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var result = JsonSerializer.Serialize(new { error = message });

            return context.Response.WriteAsync(result);
        }
    }
}
