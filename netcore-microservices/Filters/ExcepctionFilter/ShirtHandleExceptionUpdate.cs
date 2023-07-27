using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using netcore_microservices.Service;

namespace netcore_microservices.Filters.ExcepctionFilter 
{
    public class ShirtHandleExceptionUpdate : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            ShirtService customService =(ShirtService) context.HttpContext.RequestServices.GetService(typeof(ShirtService));

            var shirtId = context.RouteData.Values["id"] as string;
            if(int.TryParse(shirtId, out var id))
            {
                if(!customService.ShirtsExistsId(id))
                {
                    context.ModelState.AddModelError("shirtId","shirtid does not exists");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                   context.Result = new NotFoundObjectResult(problemDetails);

                }
            }
        }

    }
}