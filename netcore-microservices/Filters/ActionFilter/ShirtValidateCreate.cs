using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using netcore_microservices.Model;
using netcore_microservices.Repository;
using netcore_microservices.Service;

namespace netcore_microservices.Filters.Action
{
    public class ShirtValidateCreate : ActionFilterAttribute
    {
        // private readonly ShirtService shirtService;

        // public ShirtValidateCreate(ShirtService shirtService)
        // {
        //     this.shirtService = shirtService;    
        // }

        public override void OnActionExecuting(ActionExecutingContext context ) 
        {

            ShirtService customService =(ShirtService) context.HttpContext.RequestServices.GetService(typeof(ShirtService));
            base.OnActionExecuting(context);
            var shirt = context.ActionArguments["shirt"] as Shirt;

            if( shirt == null)
            {
                    context.ModelState.AddModelError("Shirt","Shirt Object is null");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };

                    context.Result = new BadRequestObjectResult(problemDetails);
            }
            else 
            {
                var existShirt = customService.ShirtByProperties(shirt.Brand, shirt.Gender, shirt.Color, shirt.Size);
                if ( existShirt != null)
                {
                    context.ModelState.AddModelError("Shirt","Shirt already exists");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };

                    context.Result = new BadRequestObjectResult(problemDetails);

                }
            }
        }


    }
}