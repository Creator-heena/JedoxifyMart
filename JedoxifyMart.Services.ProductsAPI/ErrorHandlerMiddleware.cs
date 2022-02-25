namespace JedoxifyMart.Services.ProductsAPI;

using JedoxifyMart.Services.ProductsAPI.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlerMiddleware> _logger;
    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }


    public async Task Invoke(HttpContext context)
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
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var response = context.Response;

        var errorResponse = new ResponseDto
        {
            IsSuccess = false
        };
        switch (exception)
        {
            case ApplicationException ex:
                if (ex.Message.Contains("Invalid token"))
                {
                    response.StatusCode = (int)HttpStatusCode.Forbidden;
                    errorResponse.ErrorMessage = ex.Message;
                    break;
                }
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                errorResponse.ErrorMessage = ex.Message;
                break;
            case KeyNotFoundException ex:
                response.StatusCode = (int)HttpStatusCode.NotFound;
                errorResponse.ErrorMessage = ex.Message;
                break;
            default:
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                errorResponse.ErrorMessage = "Internal Server errors. Check Logs!";
                break;
        }
        _logger.LogError(exception.Message);
        var result = JsonSerializer.Serialize(errorResponse);
        await context.Response.WriteAsync(result);
    }

}