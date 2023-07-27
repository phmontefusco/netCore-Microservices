using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using netcore_microservices.Repository;
using netcore_microservices.Service;

namespace netcore_microservices.Filters.Action
{
    public class ShirtValidateId: ActionFilterAttribute
    {

        // private readonly ShirtService shirtService;

        // public ShirtValidateId(ShirtService shirtService)
        // {
        //     this.shirtService = shirtService;    
        // }
        public override void OnActionExecuting(ActionExecutingContext context)    
        {

            ShirtService customService =(ShirtService) context.HttpContext.RequestServices.GetService(typeof(ShirtService));
            
            base.OnActionExecuting(context);
            var shirtId = context.ActionArguments["id"] as int?;
            if (shirtId.HasValue)
            {
                if(shirtId.Value <  0)
                {
                    context.ModelState.AddModelError("shirtId","shirtid is invalid");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };

                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                else if(!customService.ShirtsExistsId(shirtId.Value))
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