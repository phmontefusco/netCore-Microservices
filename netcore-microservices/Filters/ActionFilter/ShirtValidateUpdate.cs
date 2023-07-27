using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using netcore_microservices.Model;
using netcore_microservices.Service;

namespace netcore_microservices.Filters.Action
{
    public class ShirtValidateUpdate : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context ) 
        {

            ShirtService customService =(ShirtService) context.HttpContext.RequestServices.GetService(typeof(ShirtService));
            base.OnActionExecuting(context);
            var id = context.ActionArguments["id"] as int?;
            var shirt = context.ActionArguments["shirt"] as Shirt;

            if( id.HasValue &&  shirt != null && id != shirt.ShirtId)
            {
                    context.ModelState.AddModelError("Shirt","Shirt is invalid");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };

                    context.Result = new BadRequestObjectResult(problemDetails);
            }
        }

    }
}