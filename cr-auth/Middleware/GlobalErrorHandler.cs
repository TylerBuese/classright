using cr_auth.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace cr_auth.Errors
{
	public class GlobalErrorHandler
	{	
		
		private readonly RequestDelegate _next;

		public GlobalErrorHandler(RequestDelegate next) => _next = next;
		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			} catch (GenericError ex)
			{	
				
				if (ex.HttpStatusCode == null)
				{
					ex.HttpStatusCode = (int)HttpStatusCode.InternalServerError;
				}
				ProblemDetails problem = new() 
				{ 
					Status = ex.HttpStatusCode,
					Type = ex.ErrorType == null ? "Server Error" : ex.ErrorType,
					Title = ex.ErrorTitle == null ? "Server Error" : ex.ErrorTitle,
					Detail = ex.ErrorMessage == null ? "There was an issue processing the request." : ex.ErrorMessage
				};
				Enum.TryParse(typeof(HttpStatusCode), problem.Status.ToString(), out var status);
				context.Response.StatusCode = (int)status;
				var json = JsonSerializer.Serialize(problem);

				context.Response.ContentType = "application/json";

				await context.Response.WriteAsync(json);
				
			}
		}
	}
}
